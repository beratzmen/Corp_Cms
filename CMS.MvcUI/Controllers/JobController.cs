using CMS.Entities;
using CMS.Interfaces;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace CMS.MvcUI.Controllers
{
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
            if (Session["language"] != null)
            {
                Session["language"] = Session["language"];
            }
            else { Session["language"] = ""; }
            return View(_jobService.GetAll());
        }
        public ActionResult Detail(int id)
        {
            return View(_jobService.Get(id));
        }
        // iş ilanına başvuru ..
        public ActionResult Apply(int id)
        {
            return PartialView("ApplyPartial", _jobService.Get(id));
        }
        [HttpPost]
        public ActionResult Apply(HttpPostedFileBase file, JobUser jobUser)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Uploads"),
                                               Path.GetFileName(file.FileName));
                    FileInfo uploadInfo = new FileInfo(file.FileName);
                    string newUpload = Guid.NewGuid().ToString() + uploadInfo.Extension;
                    jobUser.CV = "~/Uploads/" + file.FileName + newUpload;
                    //uploadInfo.Name = newUpload;
                    //file.FileName = newUpload;
                    file.SaveAs(path + newUpload);
                    //file.SaveAs("~/Uploads"+newUpload);
                    //ViewBag.Message = "File uploaded successfully";
                    jobUser.Date = System.DateTime.Now;
                    _jobUserService.Add(jobUser);
                    Session["success"] = 1;
                    //ViewBag.deneme = true;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return RedirectToAction("List", "Job");
        }
        //[HttpPost]
        //public ActionResult Apply(JobUser jobUser, HttpPostedFileBase pdfUpload)
        //{
        //    if (pdfUpload != null)
        //    {
        //        String FileExt = Path.GetExtension(pdfUpload.FileName).ToUpper();
        //        if (FileExt == ".PDF")
        //        {
        //            Stream str = pdfUpload.InputStream;
        //            BinaryReader Br = new BinaryReader(str);
        //            Byte[] FileDet = Br.ReadBytes((Int32)str.Length);
        //            //FileDetailsModel Fd = new Models.FileDetailsModel();
        //            //Fd.FileName = pdfUpload.FileName;
        //            //Fd.FileContent = FileDet;
        //            //SaveFileDetails(Fd);
        //            jobUser.CV = FileDet;
        //        }
        //        jobUser.Date = System.DateTime.Now;
        //        _jobUserService.Add(jobUser);                
        //    }
        //    return RedirectToAction("Index", "Home");
        //}
    }
}