using CMS.Entities;
using CMS.Interfaces.User;
using CMS.MvcUI.Models;
using System;
using System.Web.Mvc;
using static CMS.MvcUI.Models.IslemSonucuEnum;

namespace CMS.MvcUI.Ares.Admin.Controllers
{

    public class LoginOrRegisterController : Controller
    {
        private IUserService _userService;
        public LoginOrRegisterController(IUserService userService)
        {
            this._userService = userService;
        }

        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SignIn(User user)
        {
            IslemSonucModel islemSonucu;
            try
            {
                var _user = _userService.userLogin(user.EMail, user.Password);
                if (_user != null)
                {
                    Session["UserId"] = _user.Id;
                    Session["UserName"] = _user.Name + " " + _user.SurName;
                    Session["RolId"] = _user.RoleID;
                    //ViewBag.RolID = _user.RolID;
                    islemSonucu = new IslemSonucModel(IslemSonucKodlari.Basarili, "Kullanıcı Girişi Başarılı");
                }
                else
                {
                    islemSonucu = new IslemSonucModel(IslemSonucKodlari.Uyari, "Kullanıcı Girişi Başarısız");
                }
            }
            catch (Exception)
            {
                islemSonucu = new IslemSonucModel(IslemSonucKodlari.Hata, "Kullanıcı Giriş Kontrol Sırasında Hata Oluştu.");
            }
            return Json(islemSonucu);
        }
        public ActionResult LogOut()
        {
            Session["UserId"] = null;
            Session.Abandon();
            return RedirectToAction("SignIn", "LoginOrRegister");
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult ForgotPassword(User user)
        //{
        //    WebMail.SmtpServer = "smtp.gmail.com";
        //    WebMail.EnableSsl = true;
        //    WebMail.SmtpPort = 587;
        //    WebMail.Send(mail.GonderilecekMail, "Konu", mail.Mesaj, mail.GondericiMail);
        //    return View();
        //}
    }
}