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
    public class VideoCommentController : Controller
    {
        // GET: VideoComment
        public ActionResult Index()
        {
            ListViewModel model = new ListViewModel();
            model.TeacherCount = TeachersServices.Instance.GetTeachersCount();
            model.StudentCount = StudentServices.Instance.GetStudentsCount();
            model.AdminCount = AccountServices.Instance.GetAccountsCount();
            model.JobsCount = JobsServices.Instance.GetJobsCount();
            model.Inbox = InboxServices.Instance.GetInboxs();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();

          
            return View(model);
        }
        public ActionResult _VideoCommentTable(string Search, int? pageNo)
        {
            VideoCommentSearchViewModel model = new VideoCommentSearchViewModel();
            model.Search = Search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.VideoComment = VideoCommentServices.Instance.GetVideoComments(Search, pageNo.Value);
            var totalrecords = VideoCommentServices.Instance.GetVideoCommentsCount(Search);


            if (model.VideoComment != null)
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
        public ActionResult _Create(NewVideoCommentViewModel model)
        {
            var newVideoComment = new VideoComments
            {
                Name = model.Name,
                Comment = model.Comment,
                Date = model.Date,
               
                Video = VideosServices.Instance.GetVideo(model.VideosID),
            };
          
            VideoCommentServices.Instance.SaveVideoComments(newVideoComment);
            return RedirectToAction("_VideoCommentTable");
        }



        [HttpPost]
        public ActionResult _Delete(VideoComments VideoComment)
        {

            VideoCommentServices.Instance.DeleteVideoComments(VideoComment.ID);
            return RedirectToAction("_VideoCommentTable");
        }




        /*********** End****************/
    }
}