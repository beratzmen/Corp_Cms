using CMS.Entities;
using CMS.Interfaces.Company;
using CMS.Interfaces.Contact;
using CMS.MvcUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace CMS.MvcUI.Controllers
{

    public class ContactController : Controller
    {
        private IContactService _contactService;
        private ICompanyService _companyService;
        public ContactController(IContactService contactService, ICompanyService companyService)
        {
            this._contactService = contactService;
            this._companyService = companyService;
        }

        //[Route("iletisim")]
        public ActionResult Index()
        {
            if (Session["language"] != null)
            {
                Session["language"] = Session["language"];
            }
            else { Session["language"] = ""; }
            ContactViewModel cvm = new ContactViewModel();
            cvm.contact = _contactService.GetAll();
            cvm.company = _companyService.GetAll().FirstOrDefault();
            return View(cvm);
        }
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(Contact contact)
        {
            _contactService.Add(contact);
            return RedirectToAction("");
        }
    }
}