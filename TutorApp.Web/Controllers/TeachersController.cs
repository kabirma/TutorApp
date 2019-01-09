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
    public class TeachersController : Controller
    {
        // GET: Teachers
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

        int items = 1;
        public ActionResult _TeacherTable(string Search, int? pageNo)
        {
            TeacherSearchViewModel model = new TeacherSearchViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = TeachersServices.Instance.GetTeachersCount(Search);
            model.Teacher = TeachersServices.Instance.GetTeachers(Search, pageNo.Value);

            if (model.Teacher != null)
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
        public ActionResult _Create(NewTeacherViewModels model)
        {

            var newTeacher = new Teachers
            {
                Name = model.Name,
                LName = model.LName,
                Email = model.Email,
                Password = model.Password,

                IsTeacher = model.IsTeacher,
                Experience = model.Experience,
                StudentType = model.StudentType,
                LessonLocation = model.LessonLocation,
                AvailableHours = model.AvailableHours,

                Gender = model.Gender,
                DOB = model.DOB,
                UndergraduateCollage = model.UndergraduateCollage,
                UndergraduateMajor = model.UndergraduateMajor,
                GraduateCollage = model.GraduateCollage,
                GraduateDegree = model.GraduateDegree,
                GraduateCollage2 = model.GraduateCollage2,
                GraduateDegree2 = model.GraduateDegree2,
                HoulryRate = model.HoulryRate,

                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                City = model.City,
                State = model.State,
                Country = model.Country,

                ZipCode = model.ZipCode,
                Bio = model.Bio,
                Facebook = model.Facebook,
                Twitter = model.Twitter,
                Google = model.Google,
                Linkedin = model.Linkedin,
                ImageUrl = model.ImageUrl,

                TeachingSubjects = CoursesFieldServices.Instance.GetCourseField(model.TeachingSubjectID)
            };
            TeachersServices.Instance.SaveTeachers(newTeacher);
            return RedirectToAction("_TeacherTable");
        }
        [HttpGet]
        public ActionResult _Edit(int ID)
        {
            var Teacher = TeachersServices.Instance.GetTeacher(ID);

            var model = new NewTeacherViewModels
            {
                Name = Teacher.Name,
                LName = Teacher.LName,
                Email = Teacher.Email,
                Password = Teacher.Password,

                IsTeacher = Teacher.IsTeacher,
                Experience = Teacher.Experience,
                StudentType = Teacher.StudentType,
                LessonLocation = Teacher.LessonLocation,
                AvailableHours = Teacher.AvailableHours,

                Gender = Teacher.Gender,
                DOB = Teacher.DOB,
                UndergraduateCollage = Teacher.UndergraduateCollage,
                UndergraduateMajor = Teacher.UndergraduateMajor,
                GraduateCollage = Teacher.GraduateCollage,
                GraduateDegree = Teacher.GraduateDegree,
                GraduateCollage2 = Teacher.GraduateCollage2,
                GraduateDegree2 = Teacher.GraduateDegree2,
                HoulryRate = Teacher.HoulryRate,

                PhoneNumber = Teacher.PhoneNumber,
                Address = Teacher.Address,
                City = Teacher.City,
                State = Teacher.State,
                Country = Teacher.Country,

                ZipCode = Teacher.ZipCode,
                Bio = Teacher.Bio,
                Facebook = Teacher.Facebook,
                Twitter = Teacher.Twitter,
                Google = Teacher.Google,
                Linkedin = Teacher.Linkedin,
                ImageUrl = Teacher.ImageUrl,

                TeachingSubjectID = Teacher.TeachingSubjects.ID,
                TeachingSubjects = CoursesFieldServices.Instance.GetCoursesField()
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Edit(NewTeacherViewModels model)
        {
            var Teacher = TeachersServices.Instance.GetTeacherdispose(model.ID);

            Teacher.Name = model.Name;
            Teacher.LName = model.LName;
            Teacher.Email = model.Email;
            Teacher.Password = model.Password;

            Teacher.IsTeacher = model.IsTeacher;
            Teacher.Experience = model.Experience;
            Teacher.StudentType = model.StudentType;
            Teacher.LessonLocation = model.LessonLocation;
            Teacher.AvailableHours = model.AvailableHours;

            Teacher.Gender = model.Gender;
            Teacher.DOB = model.DOB;
            Teacher.UndergraduateCollage = model.UndergraduateCollage;
            Teacher.UndergraduateMajor = model.UndergraduateMajor;
            Teacher.GraduateCollage = model.GraduateCollage;
            Teacher.GraduateDegree = model.GraduateDegree;
            Teacher.GraduateCollage2 = model.GraduateCollage2;
            Teacher.GraduateDegree2 = model.GraduateDegree2;
            Teacher.HoulryRate = model.HoulryRate;

            Teacher.PhoneNumber = model.PhoneNumber;
            Teacher.Address = model.Address;
            Teacher.City = model.City;
            Teacher.State = model.State;
            Teacher.Country = model.Country;

            Teacher.ZipCode = model.ZipCode;
            Teacher.Bio = model.Bio;
            Teacher.Facebook = model.Facebook;
            Teacher.Twitter = model.Twitter;
            Teacher.Google = model.Google;
            Teacher.Linkedin = model.Linkedin;
            Teacher.ImageUrl = model.ImageUrl;
            
            Teacher.TeachingSubjects = CoursesFieldServices.Instance.GetCourseField(model.TeachingSubjectID);
            
            TeachersServices.Instance.UpdateTeacher(Teacher);
            return RedirectToAction("_TeacherTable");
        }

        [HttpPost]
        public ActionResult _Delete(Teachers Teacher)
        {

            TeachersServices.Instance.DeleteTeacher(Teacher.ID);
            return RedirectToAction("_TeacherTable");
        }
    }
}