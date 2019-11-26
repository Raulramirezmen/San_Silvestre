using System;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SanSil.BLL;

namespace San_Silvestre.Security
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        private static readonly string[] RolesWhoAlwaysHaveAccess = { Enums.Roles.Developer.ToString() };

        public RoleAuthorizeAttribute(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
            {
                throw new ArgumentException("The roles parameter may only contain enums", "roles");
            }

            var temp = roles.Select(r => AddSpacesToSentence(Enum.GetName(r.GetType(), r))).ToList();
            temp.AddRange(RolesWhoAlwaysHaveAccess);
            Roles = string.Join(",", temp);
        }

        private string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            var newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (var i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                {
                    newText.Append(' ');
                }
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Redirect("/Error/Unauthorized");
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }

    }
}