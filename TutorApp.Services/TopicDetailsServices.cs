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
    public class TopicDetailsServices
    {
        #region singleton
        public static TopicDetailsServices Instance
        {
            get
            {
                if (instance == null) instance = new TopicDetailsServices();
                return instance;
            }
        }
        private static TopicDetailsServices instance { get; set; }
        private TopicDetailsServices()
        {

        }
        #endregion
        public void SaveTopicDetails(TopicDetails TopicDetail)
        {

            using (var context = new dbContext())
            {
                context.Entry(TopicDetail.Category).State = System.Data.Entity.EntityState.Unchanged;

                context.TopicDetailTable.Add(TopicDetail);
                context.SaveChanges();
            }
        }
        int items = 20;
        public List<TopicDetails> GetTopicDetails(string Search, int pageNo)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.TopicDetailTable.Where(TopicDetail => TopicDetail.Name != null && TopicDetail.Name.ToLower().Contains(Search.ToLower())).OrderBy(TopicDetail => TopicDetail.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
                else
                {
                    return context.TopicDetailTable.OrderBy(TopicDetails => TopicDetails.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
            }
        }

        public List<TopicDetails> GetTopicDetails(string Search, int pageNo, string categ)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.TopicDetailTable.Where(TopicDetail => TopicDetail.Name != null && TopicDetail.Name.ToLower().Contains(Search.ToLower())).OrderBy(TopicDetail => TopicDetail.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
                if (!string.IsNullOrEmpty(categ))
                {
                    return context.TopicDetailTable.Where(TopicDetail => TopicDetail.Name != null && TopicDetail.Category.Name == categ).OrderBy(TopicDetail => TopicDetail.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
                else
                {
                    return context.TopicDetailTable.OrderBy(TopicDetails => TopicDetails.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
            }
        }
        //public List<TopicDetails> GetTeacherTopicDetails(string Search, int pageNo, int userid)
        //{

        //    using (var context = new dbContext())
        //    {
        //        if (!string.IsNullOrEmpty(Search))
        //        {
        //            return context.TopicDetailTable.Where(Blog => Blog.Login.ID == userid && Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).OrderBy(Product => Product.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).Include(x => x.Login).ToList();
        //        }
        //        else
        //        {
        //            return context.TopicDetailTable.Where(Blog => Blog.Login.ID == userid).OrderBy(Blog => Blog.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).Include(x => x.Login).ToList();
        //        }
        //    }
        //}


        public int GetTopicDetailsCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.TopicDetailTable.Where(TopicDetail => TopicDetail.Name != null && TopicDetail.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Category).Count();
                }
                else
                {
                    return context.TopicDetailTable.Include(x => x.Category).Count();
                }
            }
        }

        public int GetTopicDetailsCount(string Search, string categ)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.TopicDetailTable.Where(TopicDetail => TopicDetail.Name != null && TopicDetail.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Category).Count();
                }
                if (!string.IsNullOrEmpty(categ))
                {
                    return context.TopicDetailTable.Where(TopicDetail => TopicDetail.Name != null && TopicDetail.Category.Name == categ).Include(x => x.Category).Count();
                }
                else
                {
                    return context.TopicDetailTable.Include(x => x.Category).Count();
                }
            }
        }
        public int GetTopicDetailsCount()
        {
            using (var context = new dbContext())
            {
                return context.TopicDetailTable.Include(x => x.Category).Count();
            }
        }


        //public int GetTeacherTopicDetailsCount(string Search, int userid)
        //{

        //    using (var context = new dbContext())
        //    {
        //        if (!string.IsNullOrEmpty(Search))
        //        {
        //            return context.TopicDetailTable.Where(Blog => Blog.Login.ID == userid && Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Category).Include(x => x.Login).Count();
        //        }
        //        else
        //        {
        //            return context.TopicDetailTable.Where(Blog => Blog.Login.ID == userid).Include(x => x.Category).Include(x => x.Login).Count();
        //        }
        //    }
        //}

        public List<TopicDetails> GetTopicDetails()
        {
            using (var context = new dbContext())
            {
                return context.TopicDetailTable.Include(x => x.Category).ToList();

            }
        }


        public TopicDetails GetTopicDetail(int ID)
        {
            var context = new dbContext();

            return context.TopicDetailTable.Include(x=>x.Category).SingleOrDefault(x => x.ID == ID);

        }


        public TopicDetails GetTopicDetaildispose(int ID)
        {
            using (var context = new dbContext())
            {

                return context.TopicDetailTable.Include(x=>x.Category).SingleOrDefault(x => x.ID == ID);
            }
        }



        public void UpdateTopicDetail(TopicDetails TopicDetail)
        {
            using (var context = new dbContext())
            {
                context.Entry(TopicDetail).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteTopicDetail(int ID)
        {
            using (var context = new dbContext())
            {
                var TopicDetail = context.TopicDetailTable.Find(ID);
                context.TopicDetailTable.Remove(TopicDetail);
                context.SaveChanges();
            }
        }

    }
}
