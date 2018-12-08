using CMS.Interfaces.NewsMember;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{
    public class BulletinMemberController : Controller
    {
        private IBulletinMemberService _bulletinMemberService;
        public BulletinMemberController(IBulletinMemberService bulletinMemberService)
        {
            this._bulletinMemberService = bulletinMemberService;
        }

        public ActionResult Index()
        {
            return View(_bulletinMemberService.GetAll());
        }
    }
}