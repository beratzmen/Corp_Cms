using CMS.Entities;
using CMS.Interfaces;
using CMS.Interfaces.Company;
using CMS.Interfaces.NewsMember;
using CMS.Interfaces.Pages;
using CMS.Interfaces.Slider;
using CMS.MvcUI.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CMS.MvcUI.Controllers
{

    //[RoutePrefix("anasayfa")]
    public class HomeController : Controller
    {
        private ICompanyService _companyService;
        private IMenuService _menuService;
        private ISliderService _sliderService;
        private IBulletinMemberService _bulletinMemberService;
        private IPagesService _pagesService;
        private IProductService _productService;
        private ISocialIconService _socialIconService;

        public HomeController(ISocialIconService socialIconService, IProductService productService,
            ICompanyService companyService, IMenuService menuService, ISliderService sliderService,
            IBulletinMemberService bulletinMemberService, IPagesService pagesService)
        {
            this._productService = productService;
            this._companyService = companyService;
            this._menuService = menuService;
            this._sliderService = sliderService;
            this._bulletinMemberService = bulletinMemberService;
            this._pagesService = pagesService;
            this._socialIconService = socialIconService;
        }

        // GET: Home        
        //[Route("anasayfa")]
        public ActionResult Index()
        {
            //Session["language"] = Session["language"] != null ? Session["language"] : "";

            if (Session["language"] != null)
            {
                Session["language"] = Session["language"];
            }
            else { Session["language"] = ""; }



            HamburgerMenuViewModel hvm = new HamburgerMenuViewModel();
            hvm.menu = _menuService.GetAll();
            hvm.slider = _sliderService.GetAll();
            //hvm.product = _productService.GetAll();      
            return View(hvm);
        }
        //[Route("anasayfa/pageShow/{pageName}")]
        public ActionResult PageDisplay(string pageName)
        {
            //ViewBag.PageTitle = "Deneme - " + pageName;
            return View(_pagesService.GetElementByName(pageName));
        }
        [HttpPost]
        public ActionResult NewsMemberSave(BulletinMember bulletinMember)
        {
            bulletinMember.Date = DateTime.Now;
            bulletinMember.Counter = 0;
            _bulletinMemberService.Add(bulletinMember);
            return RedirectToAction("Index");
        }
        public ActionResult HeaderAction()
        {
            ViewModel vm = new ViewModel();
            vm.menu = _menuService.GetAll();
            vm.company = _companyService.GetAll().FirstOrDefault();
            return PartialView("_Header", vm);
        }
        public ActionResult ChangeLanguage(string languageName)
        {
            Session["language"] = languageName;
            return RedirectToAction("Index");
        }
        public ActionResult FooterAction()
        {
            FooterViewModel fvm = new FooterViewModel();
            fvm.company = _companyService.GetAll().FirstOrDefault();
            fvm.menu = _menuService.GetAll();
            //Foooter sosyal ikonları için garip bir çözüm..
            ViewBag.Instagram = _socialIconService.GetElementByName("Instagram").Link;
            ViewBag.Facebook = _socialIconService.GetElementByName("Facebook").Link;
            ViewBag.Ios = _socialIconService.GetElementByName("Ios").Link;
            ViewBag.Google = _socialIconService.GetElementByName("Google+").Link;
            ViewBag.Android = _socialIconService.GetElementByName("Android").Link;
            ViewBag.Twitter = _socialIconService.GetElementByName("Twitter").Link;
            return PartialView("_Footer", fvm);
        }
    }
}