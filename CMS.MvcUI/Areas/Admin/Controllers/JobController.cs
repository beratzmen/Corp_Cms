using CMS.Entities;
using CMS.Interfaces;
using CMS.MvcUI.Areas.Admin.Models;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Controllers
{
    [AutCheck]
    public class JobController : Controller
    {
        private IJobService _jobService;
        private IJobUserService _jobUserService;
        public JobController(IJobService jobService, IJobUserService jobUserService)
        {
            this._jobService = jobService;
            this._jobUserService = jobUserService;
        }
        public ActionResult List()
        {
            return View(_jobService.GetAll());
        }
        public ActionResult Create()
        {
            vmJob job = new vmJob();
            return View(job);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Job job)
        {
            job.Date = System.DateTime.Now;
            _jobService.Add(job);
            return RedirectToAction("List");
        }

        public ActionResult Update(int id)
        {
            return View(_jobService.Get(id));
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(Job job)
        {
            job.Date = System.DateTime.Now;
            _jobService.Update(job);
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            _jobService.Delete(id);
            return RedirectToAction("List");
        }
    }
}