using CMS.Entities;
using CMS.Interfaces;
using CMS.Interfaces.User;
using CMS.MvcUI.Areas.Admin.Models;
using System;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{
    [AutCheck]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;
        public UserController(IUserService userService, IRoleService roleService)
        {
            this._userService = userService;
            _roleService = roleService;
        }

        //tüm kullanıcılar-adminler 
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                return View(_userService.GetAll());
            else
                return RedirectToAction("News", "News");
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            user.RoleID = 2;
            _userService.Update(user);
            return RedirectToAction("Index");
        }
        //admin sayfasında sol menüde isim,mail gösterimi.
        public ActionResult LeftMenuProfileAction()
        {
            return PartialView("_LeftMenuProfile", _userService.Get(Convert.ToInt32(Session["UserId"].ToString())));
        }
        public ActionResult Create()
        {

            return View(_roleService.GetAll());
        }
        [HttpPost]
        public ActionResult Create(User user)
        {

            //user.RolID = 2;
            _userService.Add(user);
            return RedirectToAction("Index", "User");
        }
        //kullanıcı-admin siler
        [HttpPost]
        public void UserDelete(int id)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                _userService.Delete(id);
        }
        //seçilen kullanıcının bilgilerini güncelleme
        public ActionResult UserUpdate(int id)
        {
            vmUserUpdate vmUU = new vmUserUpdate();
            vmUU.user = _userService.Get(id);
            vmUU.role = _roleService.GetAll();
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                return View(vmUU);
            else
                return RedirectToAction("News", "News");
        }
        [HttpPost]
        public ActionResult UserUpdate(User user)
        {
            _userService.Update(user);
            return RedirectToAction("Index", "User");
        }
    }
}