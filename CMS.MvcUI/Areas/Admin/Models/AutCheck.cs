using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMS.MvcUI.Areas.Admin.Models
{
    public class AutCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserId"] == null || string.IsNullOrEmpty(filterContext.HttpContext.Session["UserId"].ToString()))
            {
                //filterContext.HttpContext.Response.Redirect("/LoginOrRegister/SignIn");
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "LoginOrRegister", action = "SignIn", area="" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}