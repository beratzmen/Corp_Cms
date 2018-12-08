using CMS.Interfaces.News;
using System.Web.Mvc;

namespace CMS.MvcUI.Controllers
{
    public class NewsController : Controller
    {
        private INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            this._newsService = newsService;
        }
        // GET: News
        public ActionResult NewsPartial()
        {
            return PartialView("_NewsPartial", _newsService.GetAll());
        }
        public ActionResult NewsDetails(int id)
        {
            var news = _newsService.Get(id);
            return View(news);
        }
    }
}