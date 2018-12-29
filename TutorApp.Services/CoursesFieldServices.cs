using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Database;
using System.Data.Entity;
using TutorApp.Entities;

namespace TutorApp.Services
{
    public class CoursesFieldServices
    {
        #region singleton
        public static CoursesFieldServices Instance
        {
            get
            {
                if (instance == null) instance = new CoursesFieldServices();
                return instance;
            }
        }
        private static CoursesFieldServices instance { get; set; }
        private CoursesFieldServices()
        {

        }
        #endregion
        public void SaveCoursesField(CoursesField CourseField)
        {

            using (var context = new dbContext())
            {
                context.Entry(CourseField.Category).State = System.Data.Entity.EntityState.Unchanged;

                context.CourseFiledTable.Add(CourseField);
                context.SaveChanges();
            }
        }
        int items = 20;
        public List<CoursesField> GetCoursesField(string Search, int pageNo)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.CourseFiledTable.Where(CourseField => CourseField.Name != null && CourseField.Name.ToLower().Contains(Search.ToLower())).OrderBy(CourseField => CourseField.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
                else
                {
                    return context.CourseFiledTable.OrderBy(CoursesField => CoursesField.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
            }
        }

        public List<CoursesField> GetCoursesField(string Search, int pageNo, string categ)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.CourseFiledTable.Where(CourseField => CourseField.Name != null && CourseField.Name.ToLower().Contains(Search.ToLower())).OrderBy(CourseField => CourseField.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
                if (!string.IsNullOrEmpty(categ))
                {
                    return context.CourseFiledTable.Where(CourseField => CourseField.Name != null && CourseField.Category.Name == categ).OrderBy(CourseField => CourseField.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
                else
                {
                    return context.CourseFiledTable.OrderBy(CoursesField => CoursesField.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).ToList();
                }
            }
        }
        //public List<CoursesField> GetTeacherCoursesField(string Search, int pageNo, int userid)
        //{

        //    using (var context = new dbContext())
        //    {
        //        if (!string.IsNullOrEmpty(Search))
        //        {
        //            return context.CourseFiledTable.Where(Blog => Blog.Login.ID == userid && Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).OrderBy(Product => Product.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).Include(x => x.Login).ToList();
        //        }
        //        else
        //        {
        //            return context.CourseFiledTable.Where(Blog => Blog.Login.ID == userid).OrderBy(Blog => Blog.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Category).Include(x => x.Login).ToList();
        //        }
        //    }
        //}


        public int GetCoursesFieldCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.CourseFiledTable.Where(CourseField => CourseField.Name != null && CourseField.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Category).Count();
                }
                else
                {
                    return context.CourseFiledTable.Include(x => x.Category).Count();
                }
            }
        }

        public int GetCoursesFieldCount(string Search, string categ)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.CourseFiledTable.Where(CourseField => CourseField.Name != null && CourseField.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Category).Count();
                }
                if (!string.IsNullOrEmpty(categ))
                {
                    return context.CourseFiledTable.Where(CourseField => CourseField.Name != null && CourseField.Category.Name == categ).Include(x => x.Category).Count();
                }
                else
                {
                    return context.CourseFiledTable.Include(x => x.Category).Count();
                }
            }
        }
        public int GetCoursesFieldCount()
        {
            using (var context = new dbContext())
            {
                return context.CourseFiledTable.Include(x => x.Category).Count();
            }
        }


        //public int GetTeacherCoursesFieldCount(string Search, int userid)
        //{

        //    using (var context = new dbContext())
        //    {
        //        if (!string.IsNullOrEmpty(Search))
        //        {
        //            return context.CourseFiledTable.Where(Blog => Blog.Login.ID == userid && Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Category).Include(x => x.Login).Count();
        //        }
        //        else
        //        {
        //            return context.CourseFiledTable.Where(Blog => Blog.Login.ID == userid).Include(x => x.Category).Include(x => x.Login).Count();
        //        }
        //    }
        //}

        public List<CoursesField> GetCoursesField()
        {
            using (var context = new dbContext())
            {
                return context.CourseFiledTable.Include(x => x.Category).ToList();

            }
        }


        public CoursesField GetCourseField(int ID)
        {
            var context = new dbContext();

            return context.CourseFiledTable.Find(ID);

        }


        public CoursesField GetCourseFielddispose(int ID)
        {
            using (var context = new dbContext())
            {

                return context.CourseFiledTable.Find(ID);
            }
        }


       
        public void UpdateCourseField(CoursesField CourseField)
        {
            using (var context = new dbContext())
            {
                context.Entry(CourseField).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCourseField(int ID)
        {
            using (var context = new dbContext())
            {
                var CourseField = context.CourseFiledTable.Find(ID);
                context.CourseFiledTable.Remove(CourseField);
                context.SaveChanges();
            }
        }

    }
}
