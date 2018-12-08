using CMS.Entities;
using CMS.Interfaces;
using CMS.MvcUI.Models;
using PagedList;
using System.Web.Mvc;

namespace CMS.MvcUI.Controllers
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

        //tüm ürünler ve kategorilerin listesi.
        public ActionResult ProductShow(int page = 1, int pageSize = 4)
        {
            //Session["language"] = Session["language"] != null ? Session["language"] : "";

            if (Session["language"] != null)
            {
                Session["language"] = Session["language"];
            }
            else { Session["language"] = ""; }

            PagedList<Product> model = new PagedList<Product>(_productService.GetAll(), page, pageSize);
            CategoryProductViewModel cpvm = new CategoryProductViewModel();
            cpvm.productList = model;
            cpvm.category = _categoryService.GetAll();
            return View(cpvm);
        }
        public ActionResult ProductSearch(string Name, int page = 1, int pageSize = 4)
        {
            CategoryProductViewModel a = new CategoryProductViewModel();
            a.product = _productService.GetElementByName(Name);
            a.category = _categoryService.GetAll();
            PagedList<Product> model = new PagedList<Product>(a.product, page, pageSize);
            a.productList = model;
            return PartialView("_productSearch", a);
        }
        public ActionResult ProductByCategory(int id)
        {
            CategoryProductViewModel cpvm = new CategoryProductViewModel();
            Session["CategoryID"] = id;
            cpvm.product = _productService.GetAll();
            cpvm.category = _categoryService.GetAll();

            return PartialView("_productPartial", cpvm);
        }
        public ActionResult ProductDetails(int id)
        {
            return View(_productService.Get(id));
        }
    }
}