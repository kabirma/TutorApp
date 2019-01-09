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
    public class CoursesController : Controller
    {
        // GET: Courses
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

        public ActionResult _Coursestable(string Search, int? pageNo)
        {
            CoursesSearchViewModel model = new CoursesSearchViewModel();
            model.Search = Search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = CourseServices.Instance.GetCoursesCount(Search);
            model.Courses = CourseServices.Instance.GetCourses(Search, pageNo.Value);

            if (model.Courses != null)
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
        public ActionResult _Create(Courses Course)
        {

            CourseServices.Instance.SaveCourses(Course);
            return RedirectToAction("_Coursestable");
        }

        [HttpGet]
        public ActionResult _Edit(int ID)
        {

            return PartialView(CourseServices.Instance.GetCourse(ID));
        }
        [HttpPost]
        public ActionResult _Edit(Courses Course)
        {

            CourseServices.Instance.UpdateCourses(Course);
            return RedirectToAction("_Coursestable");
        }

        [HttpGet]
        public ActionResult _Delete(int ID)
        {
            var Courses = CourseServices.Instance.GetCourse(ID);
            return RedirectToAction("_Coursestable");
        }
        [HttpPost]
        public ActionResult _Delete(Courses Course)
        {
            CourseServices.Instance.DeleteCourses(Course.ID);
            return RedirectToAction("_Coursestable");
        }
    }
}