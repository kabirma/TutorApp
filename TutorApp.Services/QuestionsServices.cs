using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Database;
using TutorApp.Entities;

namespace TutorApp.Services
{
    public class QuestionsServices
    {

        #region singleton
        public static QuestionsServices Instance
        {
            get
            {
                if (instance == null) instance = new QuestionsServices();
                return instance;
            }
        }
        private static QuestionsServices instance { get; set; }
        private QuestionsServices()
        {

        }
        #endregion
        public void SaveQuestions(Questions Question)
        {

            using (var context = new dbContext())
            {
                context.Entry(Question.Askedby).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(Question.Subject).State = System.Data.Entity.EntityState.Unchanged;

                context.QuestionTable.Add(Question);
                context.SaveChanges();
            }
        }
        int items = 20;
        public List<Questions> GetQuestions(string Search, int pageNo)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.QuestionTable.Where(Question => Question.Name != null && Question.Name.ToLower().Contains(Search.ToLower())).OrderBy(Question => Question.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Askedby).Include(x=>x.Subject).ToList();
                }
                else
                {
                    return context.QuestionTable.OrderBy(Questions => Questions.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Askedby).Include(x=>x.Subject).ToList();
                }
            }
        }

        public List<Questions> GetQuestions(string Search, int pageNo, string askedby,string subject)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.QuestionTable.Where(Question => Question.Name != null && Question.Name.ToLower().Contains(Search.ToLower())).OrderBy(Question => Question.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Askedby).Include(x=>x.Subject).ToList();
                }
                if (!string.IsNullOrEmpty(askedby))
                {
                    return context.QuestionTable.Where(Question => Question.Name != null && Question.Askedby.Name == askedby).OrderBy(Question => Question.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Askedby).Include(x=>x.Subject).ToList();
                }
                if (!string.IsNullOrEmpty(subject))
                {
                    return context.QuestionTable.Where(Question => Question.Name != null && Question.Subject.Name == subject).OrderBy(Question => Question.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Askedby).Include(x => x.Subject).ToList();
                }
                else
                {
                    return context.QuestionTable.OrderBy(Questions => Questions.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Askedby).Include(x=>x.Subject).ToList();
                }
            }
        }
        public List<Questions> GetStudentQuestions(string Search, int pageNo, int userid)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.QuestionTable.Where(Question => Question.Askedby.ID == userid && Question.Name != null && Question.Name.ToLower().Contains(Search.ToLower())).OrderBy(Product => Product.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Askedby).Include(x => x.Subject).ToList();
                }
                else
                {
                    return context.QuestionTable.Where(Question => Question.Askedby.ID == userid).OrderBy(Question => Question.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Askedby).Include(x => x.Subject).ToList();
                }
            }
        }


        public int GetQuestionsCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.QuestionTable.Where(Question => Question.Name != null && Question.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Askedby).Include(x=>x.Subject).Count();
                }
                else
                {
                    return context.QuestionTable.Include(x => x.Askedby).Include(x=>x.Subject).Count();
                }
            }
        }

        public int GetQuestionsCount(string Search, string askedby,string subject)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.QuestionTable.Where(Question => Question.Name != null && Question.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Askedby).Include(x=>x.Subject).Count();
                }
                if (!string.IsNullOrEmpty(askedby))
                {
                    return context.QuestionTable.Where(Question => Question.Name != null && Question.Askedby.Name == askedby).Include(x => x.Askedby).Include(x=>x.Subject).Count();
                }

                if (!string.IsNullOrEmpty(subject))
                {
                    return context.QuestionTable.Where(Question => Question.Name != null && Question.Subject.Name == askedby).Include(x => x.Askedby).Include(x => x.Subject).Count();
                }
                else
                {
                    return context.QuestionTable.Include(x => x.Askedby).Include(x=>x.Subject).Count();
                }
            }
        }
        public int GetQuestionsCount()
        {
            using (var context = new dbContext())
            {
                return context.QuestionTable.Include(x => x.Askedby).Include(x=>x.Subject).Count();
            }
        }


        public int GetStudentQuestionsCount(string Search, int userid)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.QuestionTable.Where(Question => Question.Askedby.ID == userid && Question.Name != null && Question.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Askedby).Include(x => x.Subject).Count();
                }
                else
                {
                    return context.QuestionTable.Where(Question => Question.Askedby.ID == userid).Include(x => x.Askedby).Include(x => x.Subject).Count();
                }
            }
        }

        public List<Questions> GetQuestions()
        {
            using (var context = new dbContext())
            {
                return context.QuestionTable.Include(x => x.Askedby).Include(x=>x.Subject).ToList();

            }
        }


        public Questions GetQuestion(int ID)
        {
            var context = new dbContext();

            return context.QuestionTable.Include(x => x.Askedby).Include(x => x.Subject).SingleOrDefault(x => x.ID == ID);

        }


        public Questions GetQuestiondispose(int ID)
        {
            using (var context = new dbContext())
            {

                return context.QuestionTable.Include(x=>x.Askedby).Include(x=>x.Subject).SingleOrDefault(x => x.ID == ID);
            }
        }



        public void UpdateQuestion(Questions Question)
        {
            using (var context = new dbContext())
            {
                context.Entry(Question).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteQuestion(int ID)
        {
            using (var context = new dbContext())
            {
                var Question = context.QuestionTable.Find(ID);
                context.QuestionTable.Remove(Question);
                context.SaveChanges();
            }
        }

    }
}
