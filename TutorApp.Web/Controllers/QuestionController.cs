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
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index()
        {
            return View();
        }

        int items = 20;
        public ActionResult _QuestionTable(string Search, int? pageNo)
        {
            QuestionSearchViewModel model = new QuestionSearchViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = QuestionsServices.Instance.GetQuestionsCount(Search);
            model.Question = QuestionsServices.Instance.GetQuestions(Search, pageNo.Value);

            if (model.Question != null)
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
                Student=StudentServices.Instance.GetStudents()

            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Create(NewQuestionViewModels model)
        {

            var newQuestion = new Questions
            {
                Name = model.Name,
                Description = model.Description,
                Date=model.Date,
                Subject = CourseServices.Instance.GetCourse(model.SubjectID),
                Askedby = StudentServices.Instance.GetStudent(model.StudentID)
            };
            QuestionsServices.Instance.SaveQuestions(newQuestion);
            return RedirectToAction("_QuestionTable");
        }
        [HttpGet]
        public ActionResult _Edit(int ID)
        {
            var Question = QuestionsServices.Instance.GetQuestion(ID);

            var model = new NewQuestionViewModels
            {
                ID = Question.ID,
                Name = Question.Name,
                Description = Question.Description,
                Date = Question.Date,
                SubjectID = Question.Subject.ID,
                Subject = CourseServices.Instance.GetCourses(),

                StudentID = Question.Askedby.ID,
                Student = StudentServices.Instance.GetStudents()
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Edit(NewQuestionViewModels model)
        {


            var Question = QuestionsServices.Instance.GetQuestiondispose(model.ID);

            Question.Name = model.Name;
            Question.Description = model.Description;

            Question.Date = model.Date;


            Question.Subject = CourseServices.Instance.GetCourse(model.SubjectID);
            Question.Askedby = StudentServices.Instance.GetStudent(model.StudentID);


            QuestionsServices.Instance.UpdateQuestion(Question);
            return RedirectToAction("_QuestionTable");
        }

        [HttpPost]
        public ActionResult _Delete(Questions Question)
        {

            QuestionsServices.Instance.DeleteQuestion(Question.ID);
            return RedirectToAction("_QuestionTable");
        }

    }
}