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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ListViewModel model = new ListViewModel();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();

            model.Courses = CourseServices.Instance.GetCourses().Where(courses => courses.IsFeatured).Take(12).ToList();
            model.CourseFieldCount = CoursesFieldServices.Instance.GetCoursesFieldCount();
            model.Teacher = TeachersServices.Instance.GetTeachers().OrderBy(teacher => teacher.Rating).Take(10).ToList();
            model.FilesCount = FilesServices.Instance.GetFilesCount();
            model.VideoCount = VideosServices.Instance.GetVideosCount();
            model.StudentCount = StudentServices.Instance.GetStudentsCount();
            model.TeacherCount = TeachersServices.Instance.GetTeachersCount();
            model.Job = JobsServices.Instance.GetJobs();
            return View(model);
        }

        public ActionResult About()
        {
            ListViewModel model = new ListViewModel();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            return View(model);
        }
        [HttpGet]
        public ActionResult Contact()
        {
            ListViewModel model = new ListViewModel();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            return View(model);
        }
        [HttpPost]
        public ActionResult Contact(Inbox inbox)
        {
            InboxServices.Instance.SaveInbox(inbox);
            ListViewModel model = new ListViewModel();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            return View(model);
        }

        public ActionResult Lesson()
        {
            ListViewModel model = new ListViewModel();
            model.Courses = CourseServices.Instance.GetCourses();
            model.CourseField = CoursesFieldServices.Instance.GetCoursesField();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            model.CourseFieldCount = CoursesFieldServices.Instance.GetCoursesFieldCount();
            model.CoursesCount = CourseServices.Instance.GetCoursesCount();
            model.FieldTopicCount = FieldTopicsServices.Instance.GetFieldTopicsCount();
            return View(model);
        }

        public ActionResult OfflineFiles()
        {
            ListViewModel model = new ListViewModel();
            model.Files = FilesServices.Instance.GetFiles();
            model.FileCategory = FileCategServices.Instance.GetFilesCategory();
            model.Teacher = TeachersServices.Instance.GetTeachers();
            model.FilesCount = FilesServices.Instance.GetFilesCount();

            return View(model);
        }
        int items = 8;
        public ActionResult _FileData(string Search, int? pageNo,string Category,string Writer,string timeperiod)
        {
            ListViewModel model = new ListViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            
            model.Files = FilesServices.Instance.GetFiles(Search, pageNo.Value, Category, Writer,timeperiod);
            model.FilesCount = FilesServices.Instance.GetFilesCount(Search, Category, Writer);
            if (model.Files != null)
            {
                model.Pager = new Pager(model.FilesCount, pageNo, items);

                return PartialView(model);
            }
            else
            {
                return HttpNotFound();
            }
        }



    }
}