using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using SanSil.BLL;

namespace San_Silvestre.Security
{
    //public class CustomPrincipal : WindowsPrincipal
    //{

    //    public override bool IsInRole(string role)
    //    {
    //        return (base.IsInRole(role) ||
    //                (
    //                    User != null &&
    //                    User.UserRole != null &&
    //                    User.UserRole.Count > 0 &&
    //                    User.UserRole.Any(ur => ur.Role.Name == Enums.Roles.Developer.ToString() || ur.Role.Name == role)
    //                ));
    //    }

    //    public SanSil.DAL.User User { get; protected set; }
    //}
}