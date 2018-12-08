using CMS.Entities;
using CMS.Interfaces.Company;
using CMS.Interfaces.News;
using CMS.Interfaces.NewsMember;
using CMS.MvcUI.Areas.Admin.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{
    [AutCheck]
    public class NewsController : Controller
    {
        private INewsService _newsService;
        private ICompanyService _companyService;
        private IBulletinMemberService _bulletinMemberService;
        public NewsController(INewsService newsService, ICompanyService companyService, IBulletinMemberService bulletinMemberService)
        {
            this._newsService = newsService;
            this._companyService = companyService;
            this._bulletinMemberService = bulletinMemberService;
        }

        //tüm duyuruların listesi
        public ActionResult News()
        {
            return View(_newsService.GetAll());
        }
        //yeni duyuru ekleme
        //Entities'i UI'da kopyalamak yerine ihtiyaç duyulan prop. vmAdminNewsEklendi sorun çözüldü..
        public ActionResult NewsCreate()
        {
            vmAdminNews adminNews = new vmAdminNews();
            return View(adminNews);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult NewsCreate(News model, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo fotoInfo = new FileInfo(Image.FileName);
                    string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                    img.Resize(1080, 720);
                    img.Save("~/Areas/Admin/Uploads/NewsFoto/" + newFoto);
                    model.Image = "/Areas/Admin/Uploads/NewsFoto/" + newFoto;
                }
            }
            model.Date = DateTime.Now;
            _newsService.Add(model);
            return RedirectToAction("News", "News");
        }
        //duyuru silme       
        [HttpPost]
        public void NewsDelete(int id)
        {
            _newsService.Delete(id);
        }
        //Editör içeriği için get ile gelen haber newsden vmAdminNews'deki contentText'ile ekrana yazıldı.
        //duyuru güncelleme
        public ActionResult NewsUpdate(int id)
        {
            vmAdminNews anv = new vmAdminNews();
            anv.news = _newsService.Get(id);
            anv.ContentText = anv.news.ContentText;
            anv.ContentTextEN = anv.news.ContentTextEN;
            return View(anv);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult NewsUpdate(News news, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo fotoInfo = new FileInfo(Image.FileName);
                    string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                    img.Resize(1080, 720);
                    img.Save("~/Areas/Admin/Uploads/NewsFoto/" + newFoto);
                    news.Image = "/Areas/Admin/Uploads/NewsFoto/" + newFoto;
                }
            }
            _newsService.Update(news);
            return RedirectToAction("News", "News");
        }
    }
}