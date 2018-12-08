using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace CMS.MvcUI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //routes.MapMvcAttributeRoutes();

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller="Home" , action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}