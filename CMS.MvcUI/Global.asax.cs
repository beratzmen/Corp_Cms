using CMS.MvcUI.NinjectController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//using Gnostice.StarDocsSDK;

namespace CMS.MvcUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //public static StarDocs starDocs;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //starDocs = new StarDocs(
            //    new ConnectionInfo(new Uri("https://api.gnostice.com/stardocs/v1"),
            //    "a7190ab1d03c40a8b686118e29ea5834", "7420193be6ee4a5cb543053496304ee1"));
            //starDocs.Auth.loginApp();

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            GlobalFilters.Filters.Add(new HandleErrorAttribute());
        }
    }
}
