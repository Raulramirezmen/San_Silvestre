using System;
using System.IO;
using System.Configuration;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.Mvc4;
using SanSil.BLL.User.Implementation;
using SanSil.BLL.User.Interface;
using San_Silvestre.Security;

namespace San_Silvestre
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private IUserManager _userManager;

        protected void Application_Start()
        {
            //

            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrapper.Initialise();

        }

        //protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        //{
        //        var user = _userManager.GetUser(1);
        //}

    
        public static bool IsTest
        {
            get
            {
                bool isTest;
                return bool.TryParse(ConfigurationManager.AppSettings["isTest"], out isTest) && isTest;
            }
        }

        public static int GlobalCompetitionId
        {
            get
            {
                int GlobalCompetitionId = int.Parse(ConfigurationManager.AppSettings["CurrentCompetitionId"]);
                return GlobalCompetitionId;
            }
        }
    }
}
