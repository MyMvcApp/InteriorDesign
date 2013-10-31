using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InteriorDesign.Common
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           var route =  routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "InteriorDesign.Controllers.Common.Controllers.Front", "InteriorDesign.Commom.Controllers.Controllers.Front.Common" }
            );
            route.DataTokens["UseNamespaceFallback"] = false;
        }
    }
}