using CMS.Entities;
using CMS.Interfaces;
using CMS.MvcUI.Areas.Admin.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
        }

        //ürünlerin listesi
        public ActionResult ProductList()
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                return View(_productService.GetAll());
            else
                return RedirectToAction("News", "News");
        }
        //Ürün Siler
        [HttpPost]
        public void ProductDelete(int id)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                _productService.Delete(id);
        }
        //Ürün Günceller
        public ActionResult ProductUpdate(int id)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
                return View(_productService.Get(id));
            else
                return RedirectToAction("News", "News");
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ProductUpdate(Product product, HttpPostedFileBase Image)
        {
            if (Convert.ToInt32(Session["RolId"].ToString()) == 1)
            {
                if (ModelState.IsValid)
                {
                    if (Image != null)
                    {
                        WebImage img = new WebImage(Image.InputStream);
                        FileInfo fotoInfo = new FileInfo(Image.FileName);
                        string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                        img.Resize(1920, 1080);
                        img.Save("~/Areas/Admin/Uploads/ProductFoto/" + newFoto);
                        product.Image = "/Areas/Admin/Uploads/ProductFoto/" + newFoto;
                    }
                }
            }
            _productService.Update(product);
            return RedirectToAction("ProductList");

        }
        public ActionResult Create()
        {
            vmProductCreate pc = new vmProductCreate();
            pc.category = _categoryService.GetAll();
            return View(pc);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo fotoInfo = new FileInfo(Image.FileName);
                    string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                    img.Resize(1920, 1080);
                    img.Save("~/Areas/Admin/Uploads/ProductFoto/" + newFoto);
                    product.Image = "/Areas/Admin/Uploads/ProductFoto/" + newFoto;
                }
            }
            _productService.Add(product);
            return RedirectToAction("ProductList", "Product");
        }
    }
}
