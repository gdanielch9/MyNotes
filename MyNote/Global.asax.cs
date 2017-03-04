using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyNote
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CreateTempImageDirectory();
            CreateTargetImageDirectory();
        }

        private void CreateTempImageDirectory()
        {
            var tempPathString = System.Configuration.ConfigurationManager.AppSettings["tempImageDirectoryPath"];
            if (!System.IO.Directory.Exists(tempPathString))
            {
                System.IO.Directory.CreateDirectory(tempPathString);
            }
        }

        private void CreateTargetImageDirectory()
        {
            var pathString = System.Configuration.ConfigurationManager.AppSettings["imageDirectoryPath"];
            if (!System.IO.Directory.Exists(pathString))
            {
                System.IO.Directory.CreateDirectory(pathString);
            }
        }
    }
}
