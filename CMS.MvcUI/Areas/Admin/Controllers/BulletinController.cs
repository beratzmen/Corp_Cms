using CMS.Entities;
using CMS.Interfaces;
using CMS.Interfaces.Company;
using CMS.Interfaces.NewsMember;
using CMS.MvcUI.Areas.Admin.Models;
using System.Collections.Generic;
using System.Net.Mail;
using System.Web.Mvc;


namespace CMS.MvcUI.Areas.Admin.Controllers
{
    public class BulletinController : Controller
    {
        private IBulletinService _bulletinService;
        private ICompanyService _companyService;
        private IBulletinMemberService _bulletinMemberService;
        public BulletinController(IBulletinService bulletinService,
            IBulletinMemberService bulletinMemberService, ICompanyService companyService)
        {
            this._bulletinService = bulletinService;
            this._companyService = companyService;
            this._bulletinMemberService = bulletinMemberService;
        }
        public ActionResult List()
        {
            return View(_bulletinService.GetAll());
        }
        public ActionResult Create()
        {
            vmBulletinCreate bc = new vmBulletinCreate();
            return View(bc);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Bulletin bulletin)
        {
            _bulletinService.Add(bulletin);
            //bulletinmembers tablosundaki bulten abonelerine yeni bülten girildiğinde mail gönderiyor--gönderici mail gmail olmak zorunda.
            List<Company> comp = _companyService.GetAll();
            MailMessage mesajım = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential(comp[0].EMail, "proBT1212");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            List<BulletinMember> bulletinMembers = _bulletinMemberService.GetAll();
            foreach (var item in bulletinMembers)
            {
                mesajım.To.Add(item.EMail);
                mesajım.From = new MailAddress(comp[0].EMail);
                mesajım.Subject = bulletin.Title;
                mesajım.Body = bulletin.ContentText;
                istemci.Send(mesajım);
                mesajım.To.Clear();
                _bulletinMemberService.Update(item);
            }
            return RedirectToAction("List", "Bulletin");
        }
        [HttpPost]
        public void Delete(int id)
        {
            _bulletinService.Delete(id);
        }
        public ActionResult Update(int id)
        {
            vmBulletinCreate bc = new vmBulletinCreate();
            bc.bulletin = _bulletinService.Get(id);
            bc.ContentText = bc.bulletin.ContentText;
            return View(bc);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Bulletin bulletin)
        {
            _bulletinService.Update(bulletin);
            //bulletinmembers tablosundaki bulten abonelerine yeni bülten girildiğinde mail gönderiyor--gönderici mail gmail olmak zorunda.
            List<Company> comp = _companyService.GetAll();
            MailMessage mesajım = new MailMessage();
            SmtpClient istemci = new SmtpClient();                                  //şifre
            istemci.Credentials = new System.Net.NetworkCredential(comp[0].EMail, "proBT1212");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            List<BulletinMember> bulletinMembers = _bulletinMemberService.GetAll();
            foreach (var item in bulletinMembers)
            {
                mesajım.To.Add(item.EMail);
                mesajım.From = new MailAddress(comp[0].EMail);
                mesajım.Subject = bulletin.Title;
                mesajım.Body = bulletin.ContentText;
                istemci.Send(mesajım);
                mesajım.To.Clear();
                _bulletinMemberService.Update(item);
            }
            return RedirectToAction("List", "Bulletin");
        }
    }
}