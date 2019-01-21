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
    public class VideoController : Controller
    {
        // GET: Video
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

        int items = 20;
        public ActionResult _VideoTable(string Search, int? pageNo)
        {
            VideoSearchViewModel model = new VideoSearchViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = VideosServices.Instance.GetVideosCount(Search);
            model.Video = VideosServices.Instance.GetVideos(Search, pageNo.Value);

            if (model.Video != null)
            {
                model.Pager = new Pager(totalrecords, pageNo, items);

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

            var model = new ListViewModel
            {
                VideoCategory = VideoCategServices.Instance.GetVideosCategory(),
                Teacher = TeachersServices.Instance.GetTeachers()

            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Create(NewVideoViewModels model)
        {

            var newVideo = new Videos
            {
                Name = model.Name,
                Description = model.Description,
                Date = model.Date,
                FilePath = model.FilePath,
                ImageUrl=model.ImageUrl,
                Likes=model.Likes,
                Category = VideoCategServices.Instance.GetVideoCateg(model.CategoryID),
                Writer = TeachersServices.Instance.GetTeacher(model.WriterID)
            };
            VideosServices.Instance.SaveVideos(newVideo);
            return RedirectToAction("_VideoTable");
        }
        [HttpGet]
        public ActionResult _Edit(int ID)
        {
            var Video = VideosServices.Instance.GetVideo(ID);

            var model = new NewVideoViewModels
            {
                ID = Video.ID,
                Name = Video.Name,
                Description = Video.Description,
                Date = Video.Date,
                FilePath = Video.FilePath,
                ImageUrl = Video.ImageUrl,
                Likes = Video.Likes,
                CategoryID = Video.Category.ID,
                Category = VideoCategServices.Instance.GetVideosCategory(),

                WriterID = Video.Writer.ID,
                Writer = TeachersServices.Instance.GetTeachers()
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Edit(NewVideoViewModels model)
        {


            var Video = VideosServices.Instance.GetVideodispose(model.ID);

            Video.Name = model.Name;
            Video.Description = model.Description;

            Video.Date = model.Date;
            Video.FilePath = model.FilePath;
            Video.ImageUrl = model.ImageUrl;
            Video.Likes = model.Likes;
            Video.Writer = TeachersServices.Instance.GetTeacher(model.WriterID);
            Video.Category = VideoCategServices.Instance.GetVideoCateg(model.CategoryID);


            VideosServices.Instance.UpdateVideo(Video);
            return RedirectToAction("_VideoTable");
        }

        [HttpPost]
        public ActionResult _Delete(Videos Video)
        {

            VideosServices.Instance.DeleteVideo(Video.ID);
            return RedirectToAction("_VideoTable");
        }

    }
}