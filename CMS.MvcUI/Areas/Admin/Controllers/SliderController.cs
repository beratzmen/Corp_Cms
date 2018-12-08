using CMS.Entities;
using CMS.Interfaces.Slider;
using CMS.MvcUI.Areas.Admin.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{
    [AutCheck]
    public class SliderController : Controller
    {
        private ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            this._sliderService = sliderService;
        }


        //yeni  slider   resim ekleme
        public ActionResult AddSlider()
        {
            return View(_sliderService.GetAll());
        }
        [HttpPost]
        public ActionResult AddSlider(Slider slider, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                WebImage img = new WebImage(Image.InputStream);
                FileInfo fotoInfo = new FileInfo(Image.FileName);
                string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                img.Resize(1920, 1080);
                img.Save("~/Areas/Admin/Uploads/SliderFoto/" + newFoto);
                slider.Image = "/Areas/Admin/Uploads/SliderFoto/" + newFoto;
            }
            _sliderService.Add(slider);
            return RedirectToAction("AddSlider", "Slider");
        }
        //slider resim silme       
        [HttpPost]
        public void SliderDelete(int id)
        {
            _sliderService.Delete(id);
        }
        //slider resim yazı güncelleme
        public ActionResult SliderUpdate(int id)
        {
            return View(_sliderService.Get(id));
        }
        [HttpPost]
        public ActionResult SliderUpdate(Slider slider, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo fotoInfo = new FileInfo(Image.FileName);
                    string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                    img.Resize(1920, 1080);
                    img.Save("~/Areas/Admin/Uploads/SliderFoto/" + newFoto);
                    slider.Image = "/Areas/Admin/Uploads/SliderFoto/" + newFoto;
                }
            }
            _sliderService.Update(slider);
            return RedirectToAction("AddSlider", "Slider");
        }
    }
}
