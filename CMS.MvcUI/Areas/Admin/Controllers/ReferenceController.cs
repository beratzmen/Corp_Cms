using CMS.Entities;
using CMS.Interfaces.Reference;
using CMS.MvcUI.Areas.Admin.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{
    [AutCheck]
    public class ReferenceController : Controller
    {
        private IReferenceService _referenceService;
        public ReferenceController(IReferenceService referenceService)
        {
            this._referenceService = referenceService;
        }


        // tüm  referanslar - kayıt
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                return View(_referenceService.GetAll());
            else
                return RedirectToAction("News", "News");
        }
        [HttpPost]
        public ActionResult Index(Reference reference, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo fotoInfo = new FileInfo(Image.FileName);
                    string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                    img.Resize(800, 400);
                    img.Save("~/Areas/Admin/Uploads/ReferenceFoto/" + newFoto);
                    reference.Image = "/Areas/Admin/Uploads/ReferenceFoto/" + newFoto;
                }
            }
            _referenceService.Add(reference);
            return RedirectToAction("Index");
        }
        //referans siler       
        [HttpPost]
        public void ReferenceDelete(int id)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                _referenceService.Delete(id);
        }
        //referans günceller
        public ActionResult ReferenceUpdate(int id)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                return View(_referenceService.Get(id));
            else
                return RedirectToAction("News", "AdminNews");
        }
        [HttpPost]
        public ActionResult ReferenceUpdate(Reference reference, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo fotoInfo = new FileInfo(Image.FileName);
                    string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                    img.Resize(800, 400);
                    img.Save("~/Areas/Admin/Uploads/ReferenceFoto/" + newFoto);
                    reference.Image = "/Areas/Admin/Uploads/ReferenceFoto/" + newFoto;
                }
            }
            _referenceService.Update(reference);
            return RedirectToAction("Index", "Reference");
        }
    }
}