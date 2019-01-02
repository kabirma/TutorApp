using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Entities;
using TutorApp.Database;
using System.Data.Entity;

namespace TutorApp.Services
{
    public class BlogServices
    {
        #region singleton
        public static BlogServices Instance
        {
            get
            {
                if (instance == null) instance = new BlogServices();
                return instance;
            }
        }
        private static BlogServices instance { get; set; }
        private BlogServices()
        {

        }
        #endregion

        public void SaveBlogs(Blogs Blogs)
        {

            using (var context = new dbContext())
            {
                context.Entry(Blogs.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(Blogs.Category2).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(Blogs.Category3).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(Blogs.Category4).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(Blogs.Category5).State = System.Data.Entity.EntityState.Unchanged;

                context.Entry(Blogs.Writer).State = System.Data.Entity.EntityState.Unchanged;

                context.BlogTable.Add(Blogs);
                context.SaveChanges();
            }
        }
        int items = 20;
        public List<Blogs> GetBlogs(string Search, int pageNo)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.BlogTable.Where(Blog => Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).OrderBy(Blog => Blog.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).Include(x => x.Writer).ToList();
                }
                else
                {
                    return context.BlogTable.OrderBy(Blogs => Blogs.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).Include(x => x.Writer).ToList();
                }
            }
        }

        public List<Blogs> GetBlogs(string Search, int pageNo, string categ)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.BlogTable.Where(Blog => Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).OrderBy(Blog => Blog.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).Include(x => x.Writer).ToList();
                }
                if (!string.IsNullOrEmpty(categ))
                {
                    return context.BlogTable.Where(Blog => Blog.Name != null && Blog.Category.Name == categ || Blog.Category2.Name == categ || Blog.Category3.Name == categ || Blog.Category4.Name == categ || Blog.Category5.Name == categ).OrderBy(Blog => Blog.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).Include(x => x.Writer).ToList();
                }
                else
                {
                    return context.BlogTable.OrderBy(Blogs => Blogs.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).Include(x => x.Writer).ToList();
                }
            }
        }
       


        public int GetBlogsCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.BlogTable.Where(Blog => Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).Include(x => x.Writer).Count();
                }
                else
                {
                    return context.BlogTable.Include(x => x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).Include(x => x.Writer).Count();
                }
            }
        }

        public int GetBlogsCount(string Search, string categ)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.BlogTable.Where(Blog => Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).Include(x => x.Writer).Count();
                }
                if (!string.IsNullOrEmpty(categ))
                {
                    return context.BlogTable.Where(Blog => Blog.Name != null && Blog.Category.Name == categ ||  Blog.Category2.Name == categ || Blog.Category3.Name == categ || Blog.Category4.Name == categ || Blog.Category5.Name == categ  ).Include(x => x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).Include(x => x.Writer).Count();
                }
                else
                {
                    return context.BlogTable.Include(x => x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).Include(x => x.Writer).Count();
                }
            }
        }
        public int GetBlogsCount()
        {
            using (var context = new dbContext())
            {
                return context.BlogTable.Include(x => x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).Include(x => x.Writer).Count();
            }
        }


       

        public List<Blogs> GetBlogs()
        {
            using (var context = new dbContext())
            {
                return context.BlogTable.Include(x => x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).Include(x => x.Writer).ToList();

            }
        }


        public Blogs GetBlog(int ID)
        {
            var context = new dbContext();

            return context.BlogTable.Include(x=>x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).SingleOrDefault(x => x.ID == ID);

        }


        public Blogs GetBlogdispose(int ID)
        {
            using (var context = new dbContext())
            {

                return context.BlogTable.Include(x=>x.Category).Include(x => x.Category2).Include(x => x.Category3).Include(x => x.Category4).Include(x => x.Category5).SingleOrDefault(x => x.ID == ID);
            }
        }


     

        public void UpdateBlog(Blogs Blog)
        {
            using (var context = new dbContext())
            {
                context.Entry(Blog).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteBlog(int ID)
        {
            using (var context = new dbContext())
            {
                var Blog = context.BlogTable.Find(ID);
                context.BlogTable.Remove(Blog);
                context.SaveChanges();
            }
        }



        /**************** End *******************/
    }
}
