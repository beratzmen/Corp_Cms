using CMS.Entities;
using CMS.Interfaces;
using System;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{
    public class SocialIconController : Controller
    {
        private ISocialIconService _socialIconService;
        public SocialIconController(ISocialIconService socialIconService)
        {
            _socialIconService = socialIconService;
        }

        public ActionResult List()
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                return View(_socialIconService.GetAll());
            return RedirectToAction("News", "News");
        }
        public ActionResult Update(int id)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                return View(_socialIconService.Get(id));
            else
                return RedirectToAction("News", "News");
        }
        [HttpPost]
        public ActionResult Update(SocialIcon socialIcon)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                _socialIconService.Update(socialIcon);
            return RedirectToAction("List", "SocialIcon");
        }
        [HttpPost]
        public void Delete(int id)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                _socialIconService.Delete(id);
        }
    }
}