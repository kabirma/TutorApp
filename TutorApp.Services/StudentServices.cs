using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Database;
using TutorApp.Entities;

namespace TutorApp.Services
{
    public class StudentServices
    {
        #region singleton
        public static StudentServices Instance
        {
            get
            {
                if (instance == null) instance = new StudentServices();
                return instance;
            }
        }
        private static StudentServices instance { get; set; }
        private StudentServices()
        {

        }

        #endregion
        public void SaveStudents(Students Student)
        {

            using (var context = new dbContext())
            {

                context.StudentTable.Add(Student);
                context.SaveChanges();
            }
        }

        public List<Students> GetStudents(string Search, int pageNo)
        {
            int items = 3;
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.StudentTable.Where(Student => Student.Name != null && Student.Name.ToLower().Contains(Search.ToLower())).OrderBy(Student => Student.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
                else
                {
                    return context.StudentTable.OrderBy(Student => Student.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
            }
        }
        public List<Students> GetStudents()
        {
            using (var context = new dbContext())
            {
                return context.StudentTable.ToList();
            }
        }

        public int GetStudentsCount()
        {
            using (var context = new dbContext())
            {
                return context.StudentTable.Count();
            }
        }

        public int GetStudentsCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.StudentTable.Where(a => a.Name != null && a.Name.ToLower().Contains(Search.ToLower())).Count();
                }
                else
                {
                    return context.StudentTable.Count();
                }
            }
        }


        public Students GetStudent(int ID)
        {
            using (var context = new dbContext())
            { return context.StudentTable.Find(ID); }
        }

        public void UpdateStudents(Students Students)
        {

            using (var context = new dbContext())
            {
                context.Entry(Students).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteStudents(int ID)
        {
            using (var context = new dbContext())
            {
                var Students = context.StudentTable.Find(ID);

                context.StudentTable.Remove(Students);

                context.SaveChanges();

            }
        }

    }
}
