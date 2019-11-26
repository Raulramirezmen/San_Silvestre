using System;
using System.Collections.Generic;
using log4net.Repository.Hierarchy;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanSil.BLL.User.Interface;
using SanSil.DAL;
using System.Globalization;
using System.Security.Principal;

namespace SanSil.BLL.User.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly Lazy<log4net.ILog> _logger = new Lazy<log4net.ILog>(() => log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));

        public List<Models.User> GetUsers()
        {
            using (var db = new SanSilvestreEntities())
            {
                return db.User
                    .Select(x => new Models.User
                    {
                        UserId = x.UserId,
                        UserName = x.Username,
                        FullName = x.FullName,
                        EmailID = x.EmailID,
                        Password = x.Password,
                        IsActive = x.IsActive ?? false,
                        Roles = x.UserRole.Select(y => new Models.Role
                        {
                            Id = y.Role.Id,
                            Name = y.Role.Name,
                        }).ToList(),
                    }).ToList();
            }
        }

        public Models.User GetUser(int id)
        {
            using (var db = new SanSilvestreEntities())
            {
                var user = db.User.FirstOrDefault(x => x.UserId == id);
                if (user != null)
                {
                    return new Models.User
                    {
                        UserId = user.UserId,
                        UserName = user.Username,
                        FullName = user.FullName,
                        EmailID = user.EmailID,
                        Password = user.Password,
                        IsActive = user.IsActive ?? false,
                        Roles = user.UserRole.Select(y => new Models.Role
                        {
                            Id = y.Role.Id,
                            Name = y.Role.Name,
                        }).ToList()
                    };
                }
                return null;
            }
        }

        public Dictionary<string, string> GetRoleDir()
        {
            using (var db = new SanSilvestreEntities())
            {
                //TODO: Depending on role return different lists
                return db.Role.OrderBy(x => x.Id).ToDictionary(x => x.Id.ToString(CultureInfo.InvariantCulture), x => x.Name);
            }
        }

        //public Dictionary<string, int> GetUserIdDir()
        //{
        //    using (var db = new SanSilvestreEntities())
        //    {
        //        return db.User.ToDictionary(x => x.Sid, x => x.Id);
        //    }
        //}

        public int SaveUser(Models.User UserModel)
        {
            //TODO: Mapper
            var user = new DAL.User
            {
                UserId = UserModel.UserId,
                Username = UserModel.UserName,
                FullName = UserModel.FullName,
                Password = UserModel.Password,
                EmailID = UserModel.EmailID,
                IsActive = UserModel.IsActive,
                UserRole = UserModel.Roles.Select(x => new UserRole { RoleId = x.Id, UserId = UserModel.UserId }).ToList(),
            };

            using (var db = new SanSilvestreEntities())
            {
                if (user.UserId == 0)
                {
                    //Add
                    if (db.User.Any(x => x.UserId == user.UserId)) throw new ApplicationException("The user already exist in the database (same SID)");
                    db.User.Add(user);
                    db.UserRole.AddRange(user.UserRole);
                    db.SaveChanges();
                    _logger.Value.Debug(string.Format("User '{0}' added to database", user.UserId));
                }
                else
                {
                    //Edit
                    var currentUser = db.User.FirstOrDefault(x => x.UserId == user.UserId);
                    if (currentUser == null) throw new ApplicationException("The user doesn't exist in the database");

                    var userChanged = false;
                    var roleIds = user.UserRole.Select(x => x.RoleId).ToList();
                    var currentRoleIds = currentUser.UserRole.Select(x => x.RoleId).ToList();

                    //Update from domain
                    //if (currentUser.UserName != domainUser.SamAccountName)
                    //{
                    //    userChanged = true;
                    //    currentUser.UserName = domainUser.SamAccountName;
                    //}
                    //if (currentUser.DisplayName != domainUser.Name)
                    //{
                    //    userChanged = true;
                    //    currentUser.DisplayName = domainUser.Name;
                    //}
                    //Delete roles not used 
                    if (currentUser.UserRole.Any(x => !roleIds.Contains(x.RoleId)))
                    {
                        userChanged = true;
                        db.UserRole.RemoveRange(currentUser.UserRole.Where(x => !roleIds.Contains(x.RoleId)));
                    }
                    //Add new roles
                    if (user.UserRole.Any(x => !currentRoleIds.Contains(x.RoleId)))
                    {
                        userChanged = true;
                        user.UserRole.Where(x => !currentRoleIds.Contains(x.RoleId)).ToList().ForEach(x => db.UserRole.Add(new UserRole
                        {
                            RoleId = x.RoleId,
                            UserId = user.UserId
                        }));
                    }
                    ////Delete companies not used 
                    //if (currentUser.UserCompany.Any(x => !companyIds.Contains(x.CompanyId)))
                    //{
                    //    userChanged = true;
                    //    db.UserCompany.RemoveRange(currentUser.UserCompany.Where(x => !companyIds.Contains(x.CompanyId)));
                    //}
                    ////Add new roles
                    //if (user.UserCompany.Any(x => !currentCompanyIds.Contains(x.CompanyId)))
                    //{
                    //    userChanged = true;
                    //    user.UserCompany.Where(x => !currentCompanyIds.Contains(x.CompanyId)).ToList().ForEach(x => db.UserCompany.Add(new UserCompany
                    //    {
                    //        CompanyId = x.CompanyId,
                    //        UserId = user.Id
                    //    }));
                    //}
                    if (userChanged)
                    {
                        db.SaveChanges();
                        _logger.Value.Debug(string.Format("User '{0}' updated in database", user.UserId));
                    }
                }
            }
            return user.UserId;
        }

        public void RemoveUser(int id)
        {
            using (var db = new SanSilvestreEntities())
            {
                var currentUser = db.User.FirstOrDefault(x => x.UserId == id);
                if (currentUser == null) throw new ApplicationException("Usuario no existe en la base de datos");

                var userRolesRemoved = false;
                if (currentUser.UserRole.Any())
                {
                    db.UserRole.RemoveRange(currentUser.UserRole);
                    userRolesRemoved = true;
                }

                db.User.Remove(currentUser);
                db.SaveChanges();
                if (userRolesRemoved) _logger.Value.Debug(string.Format("Rol del usuario '{0}' eliminado de la base de datos", id));
                _logger.Value.Debug(string.Format("Usuario '{0}' eliminado de la base de datos", id));
            }
        }

        public DAL.User GetUpdateUser(WindowsIdentity windowsIdentity)
        {
            if (windowsIdentity.User == null) throw new ArgumentException("The user doesn't exist in the object", "windowsIdentity");
            using (var db = new SanSilvestreEntities())
            {
                var sid = windowsIdentity.User.Value;
                //var domainUser = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain, "tp1.ad1.tetrapak.com"), IdentityType.Sid, sid);
                //if (domainUser == null) throw new ArgumentException("The user is not found in the active directory", "windowsIdentity");

                var user = db.User.Include("UserRole").Include("UserRole.Role").FirstOrDefault(u => u.UserId.Equals(1));
                if (user == null)
                {
                    return new DAL.User
                    {
                        UserId = 0,
                        Username = "Unauthorized",
                        FullName = "Persona no autorizada",
                        UserRole = new List<UserRole>
                        {
                            new UserRole
                            {
                                RoleId = 99,
                                Role = new Role { Id = 4, Name = "Unauthorized" }
                            }
                        }
                    };
                }

                var userChanged = false;
                //if (user.UserName != domainUser.SamAccountName)
                //{
                //    userChanged = true;
                //    _logger.Value.Debug(string.Format("User '{0}' ({1}) changed user name from '{2}' to '{3}'", user.UserId, user.Username));
                //    user.UserName = domainUser.SamAccountName;
                //}
                //if (user.DisplayName != domainUser.Name)
                //{
                //    userChanged = true;
                //    _logger.Value.Debug(string.Format("User '{0}' ({1}) changed name from '{2}' to '{3}'", user.UserId, user.Username));
                //    user.DisplayName = domainUser.Name;
                //}
                if (userChanged)
                {
                    db.SaveChanges();
                    _logger.Value.Debug(string.Format("User '{0}' ({1}) updated with new information", user.UserId, user.Username));
                }
                return user;
            }
        }
    }
}
