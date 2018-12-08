using CMS.Interfaces.Reference;
using System.Web.Mvc;

namespace CMS.MvcUI.Controllers
{
    public class ReferenceController : Controller
    {
        private IReferenceService _referenceService;
        public ReferenceController(IReferenceService referenceService)
        {
            this._referenceService = referenceService;
        }

        public ActionResult ReferenceAction()
        {
            return PartialView("_Reference", _referenceService.GetAll());
        }
        public ActionResult List()
        {
            return View(_referenceService.GetAll());
        }
    }
}