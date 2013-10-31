using System.Web.Mvc;

namespace InteriorDesign.Common.Areas.AdminEnd
{
    public class AdminEndAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AdminEnd";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AdminEnd_default",
                "AdminEnd/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "InteriorDesign.Controllers.Common.Controllers.End", "InteriorDesign.Commom.Controllers.Controllers.End.Common" }
            );
        }
    }
}
