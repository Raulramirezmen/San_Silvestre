using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SanSil.DAL;
using SanSil.BLL;

namespace San_Silvestre.Security
{
    public class CustomRoleProvider : RoleProvider
    {

        public override bool IsUserInRole(string username, string roleName)
        {
            using (var db = new SanSilvestreEntities())
            {
                var user = db.User.FirstOrDefault(u => u.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase));

                return user != null
                       && user.UserRole != null
                       && user.UserRole.Count > 0
                       && user.UserRole.Any(ur => ur.Role.Name == Enums.Roles.Developer.ToString() || ur.Role.Name == roleName);
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            using (var db = new SanSilvestreEntities())
            {
                var user = db.User.FirstOrDefault(u => u.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase));
                return user == null ? new string[] { } : db.UserRole.Where(ur => ur.User.UserId == user.UserId).Select(ur => ur.Role.Name).ToArray();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}