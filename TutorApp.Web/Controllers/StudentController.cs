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
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Studenttable(string Search, int? pageNo)
        {
            StudentSearchViewModel model = new StudentSearchViewModel();
            model.Search = Search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = StudentServices.Instance.GetStudentsCount(Search);
            model.student = StudentServices.Instance.GetStudents(Search, pageNo.Value);

            if (model.student != null)
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
        public ActionResult _Create(Students Student)
        {

            StudentServices.Instance.SaveStudents(Student);
            return RedirectToAction("_Studenttable");
        }

        [HttpGet]
        public ActionResult _Edit(int ID)
        {

            return PartialView(StudentServices.Instance.GetStudent(ID));
        }
        [HttpPost]
        public ActionResult _Edit(Students Student)
        {

            StudentServices.Instance.UpdateStudents(Student);
            return RedirectToAction("_Studenttable");
        }

        [HttpGet]
        public ActionResult _Delete(int ID)
        {
            var Student = StudentServices.Instance.GetStudent(ID);
            return RedirectToAction("_Studenttable");
        }
        [HttpPost]
        public ActionResult _Delete(Students Student)
        {
            StudentServices.Instance.DeleteStudents(Student.ID);
            return RedirectToAction("_Studenttable");
        }

    }
}