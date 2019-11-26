using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SanSil.BLL.User.Interface;
using SanSil.BLL.User.Models;
using SanSil.BLL.Logs.Interface;
using SanSil.BLL.Logs.Implementation;
using log4net;
using SanSil.BLL;
using San_Silvestre.Security;
using San_Silvestre.Models;

namespace San_Silvestre.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        public readonly IUserManager _userManager;

        public AdminController( IUserManager userManager) : base()
        {
             _userManager = userManager;
        }

        #region Users

        //[RoleAuthorize(Enums.Roles.Administrator)]
        //[OutputCache(Duration = 0)]
        public ActionResult Users()
        {
            var userModels = GetUserModels();
            return View(userModels);
        }

        //[RoleAuthorize(Enums.Roles.Administrator)]
        //[OutputCache(Duration = 0)]
        public ActionResult EditUser(int id)
        {
            var addUser = id == 0;
            var user = _userManager.GetUser(id);
            var userModel = new UserModel
            {
                UserId = id,
                UserName = addUser ? "" : user.UserName,
                FullName = addUser ? "" : user.FullName,
                EmailID = addUser ? "" : user.EmailID,
                Password = addUser ? "" : user.Password,
                IsActive = !addUser && user.IsActive,
                ConfirmPassword = addUser ? "" : user.Password,
                RoleId = addUser || user.Roles == null || !user.Roles.Any() ? 0 : user.Roles.FirstOrDefault().Id,
                Roles = _userManager.GetRoleDir().Select(x => new SelectListItem { Value = x.Key, Text = x.Value }).ToList(),
            };
            return PartialView(userModel);
        }

        //[RoleAuthorize(Enums.Roles.Administrator)]
        //[OutputCache(Duration = 0)]
        public JsonResult SaveUser(UserModel userModel)
        {
            try
            {
                //TODO: Mapper
                var user = new User
                {
                    UserId = userModel.UserId,
                    UserName = userModel.UserName,
                    FullName = userModel.FullName,
                    EmailID = userModel.EmailID,
                    Password = userModel.Password,
                    IsActive = userModel.IsActive,
                    Roles = new List<Role> { new Role { Id = userModel.RoleId } },
                };
                var id = _userManager.SaveUser(user);
                user = _userManager.GetUser(id);
                //TODO: Mapper
                userModel = new UserModel
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    FullName = user.FullName,
                    EmailID = user.EmailID,
                    Password = user.Password,
                    IsActive = user.IsActive,
                    ExistingId = 0,
                    Role = user.Roles.Select(y => new RoleModel
                    {
                        Id = y.Id,
                        Name = y.Name,
                    }).FirstOrDefault()
                };
                //TODO: return the user object
                //Logger.Info(string.Format("User '{0}' {1}", id, userModel.UserId != 0 ? "edited" : "created"));
                return Json(userModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                //Logger.Error(exception);
                while (exception.InnerException != null) exception = exception.InnerException;
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return Json(exception.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //[RoleAuthorize(Enums.Roles.Administrator)]
        //[OutputCache(Duration = 0)]

        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            try
            {
                _userManager.RemoveUser(id);
                //Logger.Info(string.Format("User '{0}' removed", id));
                //return Json(new { success = true, message = "User deleted" }, JsonRequestBehavior.AllowGet);
                return Json(new GenericOutput { Status = true, Message = "Usuario ha sido borrado." });
            }
            catch (Exception exception)
            {
                //Logger.Error(exception);
                while (exception.InnerException != null) exception = exception.InnerException;
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return Json(exception.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //[OutputCache(Duration = 0)]
        //[RoleAuthorize(Enums.Roles.Administrator)]
        public JsonResult GetUsers()
        {
            try
            {

                var userModels = GetUserModels();
                return Json(userModels, JsonRequestBehavior.AllowGet);
                //return Json(userModels.Select(x => new
                //{
                //    x.UserId,
                //    x.UserName,
                //    x.FullName,
                //    x.EmailID,
                //    x.Password,
                //    IsActive = "<input " + (x.IsActive ? "checked='checked'" : "") + " class='check-box' disabled='disabled' type='checkbox'>",
                //    x.Role.Name,
                //    Activity = ""
                //}).ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                //Logger.Error(exception);
                while (exception.InnerException != null) exception = exception.InnerException;
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return Json(exception.Message, JsonRequestBehavior.AllowGet);
            }
        }

        private List<UserModel> GetUserModels()
        {
            var users = _userManager.GetUsers();
            //TODO: Mapper
            var userModels = users.Select(x => new UserModel
            {
                UserId = x.UserId,
                UserName = x.UserName,
                FullName = x.FullName,
                EmailID = x.EmailID,
                IsActive = x.IsActive,
                Role = x.Roles.Select(y => new RoleModel
                {
                    Id = y.Id,
                    Name = y.Name,
                }).FirstOrDefault()
            }).ToList();
            return userModels;
        }

        //private Models.UserModel GetUser(int id)
        //{
        //    using (var db = new SanSil.DAL.SanSilvestreEntities())
        //    {
        //        var user = db.User.FirstOrDefault(x => x.UserId == id);
        //        if (user != null)
        //        {
        //            return new Models.UserModel
        //            {
        //                UserId = user.UserId,
        //                UserName = user.Username,
        //                Password = user.Password,
        //                FullName = user.FullName,
        //                EmailID = user.EmailID,
        //                IsActive = user.IsActive,
        //                Role = user.UserRole.Select(y => new Models.RoleModel
        //                {
        //                    Id = y.Role.Id,
        //                    Name = y.Role.Name
        //                }).ToList()
        //            };
        //        }
        //        return null;
        //    }
        //}

        #endregion

        #region Logs
        //[RoleAuthorize(Enums.Roles.Developer)]
        //[OutputCache(Duration = 0)]
        [AllowAnonymous]
        public ActionResult Logs()
        {
            var startDate = DateTime.Today.AddDays(-0);
            var endDate = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
            var logModel = new LogModel
            {
                StartDateTime = startDate,
                EndDateTime = endDate,
                RangeDateTime = string.Format("{0} - {1}", startDate, endDate)
            };
            return View(logModel);
        }

        //[RoleAuthorize(Enums.Roles.Developer)]
        [OutputCache(Duration = 0)]
        public JsonResult GetLogs(DateTime startDateTime, DateTime endDateTime)
        {
            try
            {
                var logsManager = new LogsManager();
                var logs = logsManager.GetLogs(startDateTime, endDateTime);
                return new JsonResult { Data = logs.Select(x => new { x.Id, x.Level, x.Date, x.Source, x.Thread, x.HostName, x.User, x.Logger, x.Message, x.Exception }), MaxJsonLength = Int32.MaxValue, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception exception)
            {
                while (exception.InnerException != null) exception = exception.InnerException;
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return Json(exception.Message, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}
