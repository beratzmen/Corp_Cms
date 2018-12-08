using CMS.Interfaces;
using CMS.Interfaces.Contact;
using CMS.Interfaces.NewsMember;
using CMS.Interfaces.User;
using CMS.MvcUI.Areas.Admin.Models;
using System;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{

    [AutCheck]
    public class HomeController : Controller
    {
        private IContactService _contactService;
        private IMenuService _menuService;
        private IBulletinMemberService _bulletinMemberService;
        private IUserService _userService;
        public HomeController(IMenuService menuService, IBulletinMemberService bulletinMemberService,
                                   IUserService userService, IContactService contactService)
        {
            this._menuService = menuService;
            this._bulletinMemberService = bulletinMemberService;
            this._userService = userService;
            this._contactService = contactService;
        }


        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
            {
                ViewBag.menu = _menuService.GetAll().Count;
                ViewBag.newsmember = _bulletinMemberService.GetAll().Count;
                ViewBag.user = _userService.GetAll().Count;
                ViewBag.message = _contactService.GetAll().Count;
                return View();
            }
            else
                return RedirectToAction("News", "News");
        }

    }
}