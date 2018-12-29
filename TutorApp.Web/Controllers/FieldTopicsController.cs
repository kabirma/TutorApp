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
    public class FieldTopicsController : Controller
    {
        // GET: FieldTopics
        public ActionResult Index()
        {
            return View();
        }

        int items = 20;
        public ActionResult _FieldTopicTable(string Search, int? pageNo)
        {
            FieldTopicSearchViewModel model = new FieldTopicSearchViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = FieldTopicsServices.Instance.GetFieldTopicsCount(Search);
            model.FieldTopic = FieldTopicsServices.Instance.GetFieldTopics(Search, pageNo.Value);

            if (model.FieldTopic != null)
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
                CourseField = CoursesFieldServices.Instance.GetCoursesField(),

            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Create(NewFieldTopicViewModels model)
        {

            var newFieldTopic = new FieldTopics
            {
                Name = model.Name,
                Description = model.Description,
                Category = CoursesFieldServices.Instance.GetCourseField(model.CategoryID)
            };
            FieldTopicsServices.Instance.SaveFieldTopics(newFieldTopic);
            return RedirectToAction("_FieldTopicTable");
        }
        [HttpGet]
        public ActionResult _Edit(int ID)
        {
            var FieldTopic = FieldTopicsServices.Instance.GetFieldTopic(ID);

            var model = new NewFieldTopicViewModels
            {
                ID = FieldTopic.ID,
                Name = FieldTopic.Name,
                Description = FieldTopic.Description,

                CategoryID = FieldTopic.Category.ID,
                Categories = CoursesFieldServices.Instance.GetCoursesField()
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Edit(NewFieldTopicViewModels model)
        {


            var FieldTopic = FieldTopicsServices.Instance.GetFieldTopicdispose(model.ID);

            FieldTopic.Name = model.Name;
            FieldTopic.Description = model.Description;



            FieldTopic.Category = CoursesFieldServices.Instance.GetCourseField(model.CategoryID);


            FieldTopicsServices.Instance.UpdateFieldTopic(FieldTopic);
            return RedirectToAction("_FieldTopicTable");
        }

        [HttpPost]
        public ActionResult _Delete(FieldTopics FieldTopic)
        {

            FieldTopicsServices.Instance.DeleteFieldTopic(FieldTopic.ID);
            return RedirectToAction("_FieldTopicTable");
        }

    }
}