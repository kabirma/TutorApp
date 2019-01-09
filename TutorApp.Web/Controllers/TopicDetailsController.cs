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
    public class TopicDetailsController : Controller
    {
        // GET: TopicDetails
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
        public ActionResult _TopicDetailTable(string Search, int? pageNo)
        {
            TopicDetailSearchViewModel model = new TopicDetailSearchViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = TopicDetailsServices.Instance.GetTopicDetailsCount(Search);
            model.TopicDetail = TopicDetailsServices.Instance.GetTopicDetails(Search, pageNo.Value);

            if (model.TopicDetail != null)
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
                TopicField = FieldTopicsServices.Instance.GetFieldTopics(),

            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Create(NewTopicDetailViewModels model)
        {

            var newTopicDetail = new TopicDetails
            {
                Name = model.Name,
                Description = model.Description,
                Imageurl=model.Imageurl,
                Category = FieldTopicsServices.Instance.GetFieldTopic(model.CategoryID)
            };
            TopicDetailsServices.Instance.SaveTopicDetails(newTopicDetail);
            return RedirectToAction("_TopicDetailTable");
        }
        [HttpGet]
        public ActionResult _Edit(int ID)
        {
            var TopicDetail = TopicDetailsServices.Instance.GetTopicDetail(ID);

            var model = new NewTopicDetailViewModels
            {
                ID = TopicDetail.ID,
                Name = TopicDetail.Name,
                Description = TopicDetail.Description,
                Imageurl=TopicDetail.Imageurl,
                CategoryID = TopicDetail.Category.ID,
                Categories = FieldTopicsServices.Instance.GetFieldTopics()
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Edit(NewTopicDetailViewModels model)
        {


            var TopicDetail = TopicDetailsServices.Instance.GetTopicDetaildispose(model.ID);

            TopicDetail.Name = model.Name;
            TopicDetail.Description = model.Description;
            TopicDetail.Imageurl = model.Imageurl;


            TopicDetail.Category = FieldTopicsServices.Instance.GetFieldTopic(model.CategoryID);


            TopicDetailsServices.Instance.UpdateTopicDetail(TopicDetail);
            return RedirectToAction("_TopicDetailTable");
        }

        [HttpPost]
        public ActionResult _Delete(TopicDetails TopicDetail)
        {

            TopicDetailsServices.Instance.DeleteTopicDetail(TopicDetail.ID);
            return RedirectToAction("_TopicDetailTable");
        }
    }
}