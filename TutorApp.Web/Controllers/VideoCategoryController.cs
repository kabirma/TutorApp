using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorApp.Entities;
using TutorApp.Services;
using TutorApp.Web.ViewModels;

namespace TutorApp.Web.Controllers
{
    public class VideoCategoryController : Controller
    {
        // GET: VideoCategory
        public ActionResult Index()
        {
            ListViewModel model = new ListViewModel();
            model.TeacherCount = TeachersServices.Instance.GetTeachersCount();
            model.StudentCount = StudentServices.Instance.GetStudentsCount();
            model.AdminCount = AccountServices.Instance.GetAccountsCount();
            model.JobsCount = JobsServices.Instance.GetJobsCount();
            model.InboxCount = InboxServices.Instance.GetInboxsCount();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            model.Inbox = InboxServices.Instance.GetInboxs();
            return View(model);
        }
        public ActionResult _VideoCategtable(string Search, int? pageNo)
        {
            VideoCategSearchViewModel model = new VideoCategSearchViewModel();
            model.Search = Search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = VideoCategServices.Instance.GetVideosCategoryCount(Search);
            model.VideoCateg = VideoCategServices.Instance.GetVideosCategory(Search, pageNo.Value);

            if (model.VideoCateg != null)
            {
                model.Pager = new Pager(totalrecords, pageNo, 3);

                return PartialView(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpGet]
        public ActionResult _Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult _Create(VideosCategory VideoCateg)
        {

            VideoCategServices.Instance.SaveVideosCategory(VideoCateg);
            return RedirectToAction("_VideoCategtable");
        }

        [HttpGet]
        public ActionResult _Edit(int ID)
        {

            return PartialView(VideoCategServices.Instance.GetVideoCateg(ID));
        }
        [HttpPost]
        public ActionResult _Edit(VideosCategory VideoCateg)
        {

            VideoCategServices.Instance.UpdateVideosCategory(VideoCateg);
            return RedirectToAction("_VideoCategtable");
        }

        [HttpGet]
        public ActionResult _Delete(int ID)
        {
            var VideoCateg = VideoCategServices.Instance.GetVideoCateg(ID);
            return RedirectToAction("_VideoCategtable");
        }
        [HttpPost]
        public ActionResult _Delete(VideosCategory VideoCateg)
        {
            VideoCategServices.Instance.DeleteVideosCategory(VideoCateg.ID);
            return RedirectToAction("_VideoCategtable");
        }
    }
}