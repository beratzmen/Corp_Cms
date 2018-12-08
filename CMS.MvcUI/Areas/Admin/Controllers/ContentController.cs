using CMS.Entities;
using CMS.Interfaces;
using CMS.Interfaces.Pages;
using CMS.MvcUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{
    [AutCheck]
    public class ContentController : Controller
    {
        private IPagesService _pagesService;
        private IMenuService _menuService;
        public ContentController(IPagesService pagesService, IMenuService menuService)
        {
            this._pagesService = pagesService;
            this._menuService = menuService;
        }

        // tüm sayfaların listesi
        public ActionResult PageList()
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                return View(_pagesService.GetAll());
            else
                return RedirectToAction("News", "News");
        }

        //İSHAK ABİNİN YAPTIĞI ÇÖZÜM - ADMİNNEWS' NEWSCREATE&NEWSUPDATE ..
        //sayfa içeriği güncelleme      
        public ActionResult ContentUpdate(int id)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
            {
                Pages page = _pagesService.Get(id);
                vmAdminContentContentUpdate model = new vmAdminContentContentUpdate();
                model.ContentText = page.ContentText;
                model.ContentTextEN = page.ContentTextEN;
                model.Id = page.Id;
                model.Name = page.Name;
                model.NameEN = page.NameEN;
                model.Title = page.Title;
                model.TitleEN = page.TitleEN;
                return View(model);
            }
            else
                return RedirectToAction("News", "News");
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ContentUpdate(Pages page)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
            _pagesService.Update(page);
            return RedirectToAction("PageList", "Content");
        }
        //sayfa  silme
        [HttpPost]
        public ActionResult ContentDelete(int id)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                _pagesService.Delete(id);
            return RedirectToAction("PageList", "Content");
        }
    }
}