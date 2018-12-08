using CMS.Entities;
using CMS.Interfaces.Company;
using CMS.MvcUI.Areas.Admin.Models;
using System;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{
    [AutCheck]
    public class CompanyController : Controller
    {
        private ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        // şirket bilgileri ve güüncelleme işlemleri
        public ActionResult Index()
        {
            Company comp = _companyService.Get(1);
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                return View(comp);
            else
                return RedirectToAction("News", "News");
        }
        [HttpPost]
        public ActionResult Index(Company company)
        {
            _companyService.Update(company);
            return RedirectToAction("Index");
        }
    }
}