using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using System.Data.Entity;
using InteriorDesign.Context;
using InteriorDesign.Common.Migrations;

namespace InteriorDesign.Common
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
#if DEBUG
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InteriorDesignContext,Configuration>());
#endif
        }
    }
}