using CMS.Interfaces;
using System.Web.Mvc;

namespace CMS.MvcUI.Controllers
{
    public class ErrorController : Controller
    {
        private IMenuService _menuService;
        public ErrorController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        // GET: Error
        public ActionResult NotFound(string aspxerrorpath)
        {
            if (!string.IsNullOrWhiteSpace(aspxerrorpath))
            {
                return RedirectToAction("NotFound");
            }
            return View(_menuService.GetAll());
        }
    }
}