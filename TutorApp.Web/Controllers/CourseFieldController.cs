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
    public class CourseFieldController : Controller
    {
        // GET: CourseField
        public ActionResult Index()
        {
            return View();
        }

        int items = 20;
        public ActionResult _CourseFieldTable(string Search, int? pageNo)
        {
            CourseFieldSearchViewModel model = new CourseFieldSearchViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = CoursesFieldServices.Instance.GetCoursesFieldCount(Search);
            model.CourseField = CoursesFieldServices.Instance.GetCoursesField(Search, pageNo.Value);

            if (model.CourseField != null)
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
                Courses = CourseServices.Instance.GetCourses(),
              
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Create(NewCourseFieldViewModels model)
        {
           
            var newCourseField = new CoursesField
            {
                Name = model.Name,
                Description = model.Description,
                Category = CourseServices.Instance.GetCourse(model.CategoryID)
            };
            CoursesFieldServices.Instance.SaveCoursesField(newCourseField);
            return RedirectToAction("_CourseFieldTable");
        }
        [HttpGet]
        public ActionResult _Edit(int ID)
        {
            var CourseField = CoursesFieldServices.Instance.GetCourseField(ID);

            var model = new NewCourseFieldViewModels
            {
                ID = CourseField.ID,
                Name = CourseField.Name,
                Description = CourseField.Description,

                CategoryID = CourseField.Category.ID,
                Categories = CourseServices.Instance.GetCourses()
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Edit(NewCourseFieldViewModels model)
        {


            var CourseField = CoursesFieldServices.Instance.GetCourseFielddispose(model.ID);

            CourseField.Name = model.Name;
            CourseField.Description = model.Description;



            CourseField.Category = CourseServices.Instance.GetCourse(model.CategoryID);


            CoursesFieldServices.Instance.UpdateCourseField(CourseField);
            return RedirectToAction("_CourseFieldTable");
        }

        [HttpPost]
        public ActionResult _Delete(CoursesField CourseField)
        {

            CoursesFieldServices.Instance.DeleteCourseField(CourseField.ID);
            return RedirectToAction("_CourseFieldTable");
        }

    }
}