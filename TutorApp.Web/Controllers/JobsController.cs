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
    public class JobsController : Controller
    {
        // GET: Jobs
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
        public ActionResult _JobTable(string Search, int? pageNo)
        {
            JobSearchViewModel model = new JobSearchViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = JobsServices.Instance.GetJobsCount(Search);
            model.Job = JobsServices.Instance.GetJobs(Search, pageNo.Value);

            if (model.Job != null)
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
                Student = StudentServices.Instance.GetStudents()

            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Create(NewJobViewModels model)
        {

            var newJob = new Jobs
            {
                Name = model.Name,
                Description = model.Description,
                Date = model.Date,
                Availability = model.Availability,
                Location = model.Location,
                LessonBegins = model.LessonBegins,
                GradingLevel = model.GradingLevel,
                Course = CourseServices.Instance.GetCourse(model.CourseID),
                Student = StudentServices.Instance.GetStudent(model.StudentID)
            };
            JobsServices.Instance.SaveJobs(newJob);
            return RedirectToAction("_JobTable");
        }
        [HttpGet]
        public ActionResult _Edit(int ID)
        {
            var Job = JobsServices.Instance.GetJob(ID);

            var model = new NewJobViewModels
            {
                ID = Job.ID,
                Name = Job.Name,
                Description = Job.Description,
                Date = Job.Date,
                Availability = Job.Availability,
                Location = Job.Location,
                LessonBegins = Job.LessonBegins,
                GradingLevel=Job.GradingLevel,
                CourseID = Job.Course.ID,
                Subject = CourseServices.Instance.GetCourses(),

                StudentID = Job.Student.ID,
                Student = StudentServices.Instance.GetStudents()
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Edit(NewJobViewModels model)
        {


            var Job = JobsServices.Instance.GetJobdispose(model.ID);

            Job.Name = model.Name;
            Job.Description = model.Description;
            Job.GradingLevel = model.GradingLevel;
            Job.Date = model.Date;
            Job.LessonBegins = model.LessonBegins;
            Job.Location = model.Location;
            Job.Availability = model.Availability;

            Job.Course = CourseServices.Instance.GetCourse(model.CourseID);
            Job.Student = StudentServices.Instance.GetStudent(model.StudentID);


            JobsServices.Instance.UpdateJob(Job);
            return RedirectToAction("_JobTable");
        }

        [HttpPost]
        public ActionResult _Delete(Jobs Job)
        {

            JobsServices.Instance.DeleteJob(Job.ID);
            return RedirectToAction("_JobTable");
        }

    }
}