using CMS.Entities;
using CMS.Interfaces;
using CMS.Interfaces.Pages;
using CMS.MvcUI.Areas.Admin.Models;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{
    [AutCheck]
    public class MenuController : Controller
    {
        private IMenuService _menuService;
        private IPagesService _pagesService;
        public MenuController(IMenuService menuService, IPagesService pagesService)
        {
            _menuService = menuService;
            _pagesService = pagesService;
        }


        //yeni menü ekleme
        public ActionResult MenuEkle()
        {
            return View(_menuService.GetAll());
        }
        [HttpPost]
        public ActionResult MenuEkle(Menu menu)
        {
            Pages page = new Pages();
            page.Name = menu.Link;
            page.NameEN = menu.NameENG;
            _pagesService.Add(page);
            menu.Link = "/home/PageDisplay/?pageName=" + menu.Link;
            _menuService.Add(menu);
            return RedirectToAction("MenuEkle", "Menu");
        }
        //menü silme
        [HttpPost]
        public void MenuDelete(int id)
        {
            _menuService.Delete(id);
        }
        //menü güncelleme
        public ActionResult MenuUpdate(int id)
        {
            Menu menu = _menuService.Get(id);
            ViewBag.menu = menu;
            return View(_menuService.GetAll());
        }
        [HttpPost]
        public ActionResult MenuUpdate(Menu menu)
        {
            _menuService.Update(menu);
            return RedirectToAction("MenuEkle", "Menu");
        }

    }
}