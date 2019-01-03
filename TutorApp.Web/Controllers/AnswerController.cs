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
    public class AnswerController : Controller
    {
        // GET: Answer
        public ActionResult Index()
        {
            ListViewModel model = new ListViewModel();
            model.TeacherCount = TeachersServices.Instance.GetTeachersCount();
            model.StudentCount = StudentServices.Instance.GetStudentsCount();
            model.AdminCount = AccountServices.Instance.GetAccountsCount();
            return View(model);
        }

        int items = 20;
        public ActionResult _AnswerTable(string Search, int? pageNo)
        {
            AnswerSearchViewModel model = new AnswerSearchViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = AnswersServices.Instance.GetAnswersCount(Search);
            model.Answer = AnswersServices.Instance.GetAnswers(Search, pageNo.Value);

            if (model.Answer != null)
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
                Teacher = TeachersServices.Instance.GetTeachers(),
                Question = QuestionsServices.Instance.GetQuestions()

            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Create(NewAnswerViewModels model)
        {

            var newAnswer = new Answers
            {
                Name = model.Name,
                Description = model.Description,
                Date = model.Date,
                Upvote=model.Upvote,
                Downvote=model.Downvote,
                AnsweredBy = TeachersServices.Instance.GetTeacher(model.AnsweredByID),
                Question = QuestionsServices.Instance.GetQuestion(model.QuestionID)
            };
            AnswersServices.Instance.SaveAnswers(newAnswer);
            return RedirectToAction("_AnswerTable");
        }
        [HttpGet]
        public ActionResult _Edit(int ID)
        {
            var Answer = AnswersServices.Instance.GetAnswer(ID);

            var model = new NewAnswerViewModels
            {
                ID = Answer.ID,
                Name = Answer.Name,
                Description = Answer.Description,
                Date = Answer.Date,
                Upvote=Answer.Upvote,
                Downvote=Answer.Downvote,

                AnsweredByID = Answer.AnsweredBy.ID,
                AnsweredBy = TeachersServices.Instance.GetTeachers(),

                QuestionID = Answer.Question.ID,
                Question = QuestionsServices.Instance.GetQuestions()
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Edit(NewAnswerViewModels model)
        {


            var Answer = AnswersServices.Instance.GetAnswerdispose(model.ID);

            Answer.Name = model.Name;
            Answer.Description = model.Description;

            Answer.Date = model.Date;
            Answer.Upvote = model.Upvote;
            Answer.Downvote = model.Downvote;

            Answer.AnsweredBy = TeachersServices.Instance.GetTeacher(model.AnsweredByID);
            Answer.Question = QuestionsServices.Instance.GetQuestion(model.QuestionID);


            AnswersServices.Instance.UpdateAnswer(Answer);
            return RedirectToAction("_AnswerTable");
        }

        [HttpPost]
        public ActionResult _Delete(Answers Answer)
        {

            AnswersServices.Instance.DeleteAnswer(Answer.ID);
            return RedirectToAction("_AnswerTable");
        }
    }
}