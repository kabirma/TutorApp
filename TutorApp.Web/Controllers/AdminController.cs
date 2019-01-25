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
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                ListViewModel model = new ListViewModel();
                model.CoursesCount = CourseServices.Instance.GetCoursesCount();
                model.QuestionCount = QuestionsServices.Instance.GetQuestionsCount();
                model.FilesCount = FilesServices.Instance.GetFilesCount();
                model.VideoCount = VideosServices.Instance.GetVideosCount();

                model.AdminCount = AccountServices.Instance.GetAccountsCount();
                model.TeacherCount = TeachersServices.Instance.GetTeachersCount();
                model.StudentCount = StudentServices.Instance.GetStudentsCount();
                model.JobsCount = JobsServices.Instance.GetJobsCount();
                model.InboxCount = InboxServices.Instance.GetInboxsCount();

                model.Teachers = TeachersServices.Instance.GetTeachers();

                model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
                model.Inbox = InboxServices.Instance.GetInboxs();
                model.Courses = CourseServices.Instance.GetCourses();
                return View(model);
            }
            else { return RedirectToAction("Signin"); }

        }

        [HttpGet]
        public ActionResult Signin()
        {
            ListViewModel model = new ListViewModel();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            return View(model);
        }

        [HttpPost]
        public ActionResult Signin(Accounts account)
        {
            var check = AdminServices.Instance.Signin(account);
            if (check != null)
            {
                Session["username"] = account.Email.ToString();
                ListViewModel model = new ListViewModel();
                model.CoursesCount = CourseServices.Instance.GetCoursesCount();
                model.QuestionCount = QuestionsServices.Instance.GetQuestionsCount();
                model.FilesCount = FilesServices.Instance.GetFilesCount();
                model.VideoCount = VideosServices.Instance.GetVideosCount();

                model.AdminCount = AccountServices.Instance.GetAccountsCount();
                model.TeacherCount = TeachersServices.Instance.GetTeachersCount();
                model.StudentCount = StudentServices.Instance.GetStudentsCount();
                model.JobsCount = JobsServices.Instance.GetJobsCount();
                model.InboxCount = InboxServices.Instance.GetInboxsCount();

                model.Teachers = TeachersServices.Instance.GetTeachers();
                model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();

                model.Inbox = InboxServices.Instance.GetInboxs();
                model.Courses = CourseServices.Instance.GetCourses();
                return RedirectToAction("Index",model);
            }
            else
            {
                
                return View("Signin");
            }
        }

        public ActionResult Signout()
        {
            Session["username"] = null;
            return View("Signin");
        }

    }
}