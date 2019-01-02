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
    public class FieldTopicsServices
    {
        #region singleton
        public static FieldTopicsServices Instance
        {
            get
            {
                if (instance == null) instance = new FieldTopicsServices();
                return instance;
            }
        }
        private static FieldTopicsServices instance { get; set; }
        private FieldTopicsServices()
        {

        }
        #endregion
        public void SaveFieldTopics(FieldTopics FieldTopic)
        {

            using (var context = new dbContext())
            {
                context.Entry(FieldTopic.Category).State = System.Data.Entity.EntityState.Unchanged;

                context.FieldTopicTable.Add(FieldTopic);
                context.SaveChanges();
            }
        }
        int items = 20;
        public List<FieldTopics> GetFieldTopics(string Search, int pageNo)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.FieldTopicTable.Where(FieldTopic => FieldTopic.Name != null && FieldTopic.Name.ToLower().Contains(Search.ToLower())).OrderBy(FieldTopic => FieldTopic.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
                else
                {
                    return context.FieldTopicTable.OrderBy(FieldTopics => FieldTopics.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
            }
        }

        public List<FieldTopics> GetFieldTopics(string Search, int pageNo, string categ)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.FieldTopicTable.Where(FieldTopic => FieldTopic.Name != null && FieldTopic.Name.ToLower().Contains(Search.ToLower())).OrderBy(FieldTopic => FieldTopic.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
                if (!string.IsNullOrEmpty(categ))
                {
                    return context.FieldTopicTable.Where(FieldTopic => FieldTopic.Name != null && FieldTopic.Category.Name == categ).OrderBy(FieldTopic => FieldTopic.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
                else
                {
                    return context.FieldTopicTable.OrderBy(FieldTopics => FieldTopics.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
            }
        }
        //public List<FieldTopics> GetTeacherFieldTopics(string Search, int pageNo, int userid)
        //{

        //    using (var context = new dbContext())
        //    {
        //        if (!string.IsNullOrEmpty(Search))
        //        {
        //            return context.FieldTopicTable.Where(Blog => Blog.Login.ID == userid && Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).OrderBy(Product => Product.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).Include(x => x.Login).ToList();
        //        }
        //        else
        //        {
        //            return context.FieldTopicTable.Where(Blog => Blog.Login.ID == userid).OrderBy(Blog => Blog.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).Include(x => x.Login).ToList();
        //        }
        //    }
        //}


        public int GetFieldTopicsCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.FieldTopicTable.Where(FieldTopic => FieldTopic.Name != null && FieldTopic.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Category).Count();
                }
                else
                {
                    return context.FieldTopicTable.Include(x => x.Category).Count();
                }
            }
        }

        public int GetFieldTopicsCount(string Search, string categ)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.FieldTopicTable.Where(FieldTopic => FieldTopic.Name != null && FieldTopic.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Category).Count();
                }
                if (!string.IsNullOrEmpty(categ))
                {
                    return context.FieldTopicTable.Where(FieldTopic => FieldTopic.Name != null && FieldTopic.Category.Name == categ).Include(x => x.Category).Count();
                }
                else
                {
                    return context.FieldTopicTable.Include(x => x.Category).Count();
                }
            }
        }
        public int GetFieldTopicsCount()
        {
            using (var context = new dbContext())
            {
                return context.FieldTopicTable.Include(x => x.Category).Count();
            }
        }


        //public int GetTeacherFieldTopicsCount(string Search, int userid)
        //{

        //    using (var context = new dbContext())
        //    {
        //        if (!string.IsNullOrEmpty(Search))
        //        {
        //            return context.FieldTopicTable.Where(Blog => Blog.Login.ID == userid && Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Category).Include(x => x.Login).Count();
        //        }
        //        else
        //        {
        //            return context.FieldTopicTable.Where(Blog => Blog.Login.ID == userid).Include(x => x.Category).Include(x => x.Login).Count();
        //        }
        //    }
        //}

        public List<FieldTopics> GetFieldTopics()
        {
            using (var context = new dbContext())
            {
                return context.FieldTopicTable.Include(x => x.Category).ToList();

            }
        }


        public FieldTopics GetFieldTopic(int ID)
        {
            var context = new dbContext();

            return context.FieldTopicTable.Include(x=>x.Category).SingleOrDefault(x => x.ID == ID);

        }


        public FieldTopics GetFieldTopicdispose(int ID)
        {
            using (var context = new dbContext())
            {

                return context.FieldTopicTable.Include(x=>x.Category).SingleOrDefault(x => x.ID == ID);
            }
        }



        public void UpdateFieldTopic(FieldTopics FieldTopic)
        {
            using (var context = new dbContext())
            {
                context.Entry(FieldTopic).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteFieldTopic(int ID)
        {
            using (var context = new dbContext())
            {
                var FieldTopic = context.FieldTopicTable.Find(ID);
                context.FieldTopicTable.Remove(FieldTopic);
                context.SaveChanges();
            }
        }
    }
}
