using CMS.Interfaces.Contact;
using CMS.MvcUI.Areas.Admin.Models;
using System;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{
    [AutCheck]
    public class ContactController : Controller
    {
        private IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            this._contactService = contactService;
        }
        // GET: Admin/AdminContact
        public ActionResult ShowMessage()
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                return View(_contactService.GetAll());
            else
                return RedirectToAction("News", "News");
        }
        [HttpPost]
        public void MessageDelete(int id)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                _contactService.Delete(id);
        }
    }
}