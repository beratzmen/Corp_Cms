using CMS.Entities;
using CMS.Interfaces;
using CMS.MvcUI.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;


namespace CMS.MvcUI.Areas.Admin.Controllers
{
    [AutCheck]
    public class JobUserController : Controller
    {
        private IJobUserService _jobUserService;
        public JobUserController(IJobUserService jobUserService)
        {
            this._jobUserService = jobUserService;
        }

        public FileResult Download(string file)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath(/*"~/Uploads/" +*/ file /*+ ""*/));
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file);
        }

        // GET: JobUser
        public ActionResult List(int id)
        {
            var list = _jobUserService.GetAll();
            List<JobUser> jobUser = new List<JobUser>();
            foreach (var item in list)
            {
                if (item.JobID == id)
                {
                    jobUser.Add(item);
                }
            }

            return View(jobUser);
        }
        [HttpPost]
        public string Delete(int id)
        {
            _jobUserService.Delete(id);
            return "Kayıt Silindi";
            //return RedirectToAction("List", "Job");
        }
    }
}