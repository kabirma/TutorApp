using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Database;
using TutorApp.Entities;
using System.Data.Entity;

namespace TutorApp.Services
{
    public class AnswersServices
    {

        #region singleton
        public static AnswersServices Instance
        {
            get
            {
                if (instance == null) instance = new AnswersServices();
                return instance;
            }
        }
        private static AnswersServices instance { get; set; }
        private AnswersServices()
        {

        }
        #endregion
        public void SaveAnswers(Answers Answer)
        {

            using (var context = new dbContext())
            {
                context.Entry(Answer.AnsweredBy).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(Answer.Question).State = System.Data.Entity.EntityState.Unchanged;

                context.AnswerTable.Add(Answer);
                context.SaveChanges();
            }
        }
        int items = 20;
        public List<Answers> GetAnswers(string Search, int pageNo)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.AnswerTable.Where(Answer => Answer.Name != null && Answer.Name.ToLower().Contains(Search.ToLower())).OrderBy(Answer => Answer.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.AnsweredBy).Include(x => x.Question).ToList();
                }
                else
                {
                    return context.AnswerTable.OrderBy(Answers => Answers.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.AnsweredBy).Include(x => x.Question).ToList();
                }
            }
        }

        public List<Answers> GetAnswers(string Search, int pageNo, string AnsweredBy, string Question)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.AnswerTable.Where(Answer => Answer.Name != null && Answer.Name.ToLower().Contains(Search.ToLower())).OrderBy(Answer => Answer.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.AnsweredBy).Include(x => x.Question).ToList();
                }
                if (!string.IsNullOrEmpty(AnsweredBy))
                {
                    return context.AnswerTable.Where(Answer => Answer.Name != null && Answer.AnsweredBy.Name == AnsweredBy).OrderBy(Answer => Answer.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.AnsweredBy).Include(x => x.Question).ToList();
                }
                if (!string.IsNullOrEmpty(Question))
                {
                    return context.AnswerTable.Where(Answer => Answer.Name != null && Answer.Question.Name == Question).OrderBy(Answer => Answer.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.AnsweredBy).Include(x => x.Question).ToList();
                }
                else
                {
                    return context.AnswerTable.OrderBy(Answers => Answers.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.AnsweredBy).Include(x => x.Question).ToList();
                }
            }
        }
        public List<Answers> GetStudentAnswers(string Search, int pageNo, int userid)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.AnswerTable.Where(Answer => Answer.AnsweredBy.ID == userid && Answer.Name != null && Answer.Name.ToLower().Contains(Search.ToLower())).OrderBy(Product => Product.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.AnsweredBy).Include(x => x.Question).ToList();
                }
                else
                {
                    return context.AnswerTable.Where(Answer => Answer.AnsweredBy.ID == userid).OrderBy(Answer => Answer.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.AnsweredBy).Include(x => x.Question).ToList();
                }
            }
        }


        public int GetAnswersCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.AnswerTable.Where(Answer => Answer.Name != null && Answer.Name.ToLower().Contains(Search.ToLower())).Include(x => x.AnsweredBy).Include(x => x.Question).Count();
                }
                else
                {
                    return context.AnswerTable.Include(x => x.AnsweredBy).Include(x => x.Question).Count();
                }
            }
        }

        public int GetAnswersCount(string Search, string AnsweredBy, string Question)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.AnswerTable.Where(Answer => Answer.Name != null && Answer.Name.ToLower().Contains(Search.ToLower())).Include(x => x.AnsweredBy).Include(x => x.Question).Count();
                }
                if (!string.IsNullOrEmpty(AnsweredBy))
                {
                    return context.AnswerTable.Where(Answer => Answer.Name != null && Answer.AnsweredBy.Name == AnsweredBy).Include(x => x.AnsweredBy).Include(x => x.Question).Count();
                }

                if (!string.IsNullOrEmpty(Question))
                {
                    return context.AnswerTable.Where(Answer => Answer.Name != null && Answer.Question.Name == AnsweredBy).Include(x => x.AnsweredBy).Include(x => x.Question).Count();
                }
                else
                {
                    return context.AnswerTable.Include(x => x.AnsweredBy).Include(x => x.Question).Count();
                }
            }
        }
        public int GetAnswersCount()
        {
            using (var context = new dbContext())
            {
                return context.AnswerTable.Include(x => x.AnsweredBy).Include(x => x.Question).Count();
            }
        }


        public int GetStudentAnswersCount(string Search, int userid)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.AnswerTable.Where(Answer => Answer.AnsweredBy.ID == userid && Answer.Name != null && Answer.Name.ToLower().Contains(Search.ToLower())).Include(x => x.AnsweredBy).Include(x => x.Question).Count();
                }
                else
                {
                    return context.AnswerTable.Where(Answer => Answer.AnsweredBy.ID == userid).Include(x => x.AnsweredBy).Include(x => x.Question).Count();
                }
            }
        }

        public List<Answers> GetAnswers()
        {
            using (var context = new dbContext())
            {
                return context.AnswerTable.Include(x => x.AnsweredBy).Include(x => x.Question).ToList();

            }
        }


        public Answers GetAnswer(int ID)
        {
            var context = new dbContext();

            return context.AnswerTable.Include(x => x.AnsweredBy).Include(x => x.Question).SingleOrDefault(x => x.ID == ID);

        }


        public Answers GetAnswerdispose(int ID)
        {
            using (var context = new dbContext())
            {

                return context.AnswerTable.Include(x => x.AnsweredBy).Include(x => x.Question).SingleOrDefault(x => x.ID == ID);
            }
        }



        public void UpdateAnswer(Answers Answer)
        {
            using (var context = new dbContext())
            {
                context.Entry(Answer).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteAnswer(int ID)
        {
            using (var context = new dbContext())
            {
                var Answer = context.AnswerTable.Find(ID);
                context.AnswerTable.Remove(Answer);
                context.SaveChanges();
            }
        }

    }
}
