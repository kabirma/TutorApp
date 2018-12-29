using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Database;
using TutorApp.Entities;

namespace TutorApp.Services
{
    public class CourseServices
    {
        #region singleton
        public static CourseServices Instance
        {
            get
            {
                if (instance == null) instance = new CourseServices();
                return instance;
            }
        }
        private static CourseServices instance { get; set; }
        private CourseServices()
        {

        }

#endregion
        public void SaveCourses(Courses Course)
        {

            using (var context = new dbContext())
            {

                context.CourseTable.Add(Course);
                context.SaveChanges();
            }
        }

        public List<Courses> GetCourses(string Search, int pageNo)
        {
            int items = 3;
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.CourseTable.Where(Course => Course.Name != null && Course.Name.ToLower().Contains(Search.ToLower())).OrderBy(Course => Course.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
                else
                {
                    return context.CourseTable.OrderBy(Course => Course.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
            }
        }
        public List<Courses> GetCourses()
        {
            using (var context = new dbContext())
            {
                return context.CourseTable.ToList();
            }
        }

        public int GetCoursesCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.CourseTable.Where(a => a.Name != null && a.Name.ToLower().Contains(Search.ToLower())).Count();
                }
                else
                {
                    return context.CourseTable.Count();
                }
            }
        }

     
        public Courses GetCourse(int ID)
        {
            using (var context = new dbContext())
            { return context.CourseTable.Find(ID); }
        }

        public void UpdateCourses(Courses Courses)
        {

            using (var context = new dbContext())
            {
                context.Entry(Courses).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCourses(int ID)
        {
            using (var context = new dbContext())
            {
                var Courses = context.CourseTable.Find(ID);
               
                context.CourseTable.Remove(Courses);

                context.SaveChanges();

            }
        }
    }
}
