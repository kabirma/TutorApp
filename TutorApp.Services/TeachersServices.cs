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
    public class TeachersServices
    {
        #region singleton
        public static TeachersServices Instance
        {
            get
            {
                if (instance == null) instance = new TeachersServices();
                return instance;
            }
        }
        private static TeachersServices instance { get; set; }
        private TeachersServices()
        {

        }
        #endregion
        public void SaveTeachers(Teachers Teacher)
        {

            using (var context = new dbContext())
            {
                context.Entry(Teacher.TeachingSubjects).State = System.Data.Entity.EntityState.Unchanged;

                context.TeacherTable.Add(Teacher);
                context.SaveChanges();
            }
        }
        int items = 20;
        public List<Teachers> GetTeachers(string Search, int pageNo)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.TeacherTable.Where(Teacher => Teacher.Name != null && Teacher.Name.ToLower().Contains(Search.ToLower())).OrderBy(Teacher => Teacher.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).ToList();
                }
                else
                {
                    return context.TeacherTable.OrderBy(Teachers => Teachers.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).ToList();
                }
            }
        }

        public List<Teachers> GetTeachers(string Search, int pageNo, string categ)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.TeacherTable.Where(Teacher => Teacher.Name != null && Teacher.Name.ToLower().Contains(Search.ToLower())).OrderBy(Teacher => Teacher.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).ToList();
                }
                if (!string.IsNullOrEmpty(categ))
                {
                    return context.TeacherTable.Where(Teacher => Teacher.Name != null && Teacher.TeachingSubjects.Name == categ).OrderBy(Teacher => Teacher.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).ToList();
                }
                else
                {
                    return context.TeacherTable.OrderBy(Teachers => Teachers.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).ToList();
                }
            }
        }
        //public List<Teachers> GetTeacherTeachers(string Search, int pageNo, int userid)
        //{

        //    using (var context = new dbContext())
        //    {
        //        if (!string.IsNullOrEmpty(Search))
        //        {
        //            return context.TeacherTable.Where(Blog => Blog.Login.ID == userid && Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).OrderBy(Product => Product.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).Include(x => x.Login).ToList();
        //        }
        //        else
        //        {
        //            return context.TeacherTable.Where(Blog => Blog.Login.ID == userid).OrderBy(Blog => Blog.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).Include(x => x.Login).ToList();
        //        }
        //    }
        //}


        public int GetTeachersCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.TeacherTable.Where(Teacher => Teacher.Name != null && Teacher.Name.ToLower().Contains(Search.ToLower())).Include(x => x.TeachingSubjects).Count();
                }
                else
                {
                    return context.TeacherTable.Include(x => x.TeachingSubjects).Count();
                }
            }
        }

        public int GetTeachersCount(string Search, string categ)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.TeacherTable.Where(Teacher => Teacher.Name != null && Teacher.Name.ToLower().Contains(Search.ToLower())).Include(x => x.TeachingSubjects).Count();
                }
                if (!string.IsNullOrEmpty(categ))
                {
                    return context.TeacherTable.Where(Teacher => Teacher.Name != null && Teacher.TeachingSubjects.Name == categ).Include(x => x.TeachingSubjects).Count();
                }
                else
                {
                    return context.TeacherTable.Include(x => x.TeachingSubjects).Count();
                }
            }
        }
        public int GetTeachersCount()
        {
            using (var context = new dbContext())
            {
                return context.TeacherTable.Include(x => x.TeachingSubjects).Count();
            }
        }


        //public int GetTeacherTeachersCount(string Search, int userid)
        //{

        //    using (var context = new dbContext())
        //    {
        //        if (!string.IsNullOrEmpty(Search))
        //        {
        //            return context.TeacherTable.Where(Blog => Blog.Login.ID == userid && Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).Include(x => x.TeachingSubjects).Include(x => x.Login).Count();
        //        }
        //        else
        //        {
        //            return context.TeacherTable.Where(Blog => Blog.Login.ID == userid).Include(x => x.TeachingSubjects).Include(x => x.Login).Count();
        //        }
        //    }
        //}

        public List<Teachers> GetTeachers()
        {
            using (var context = new dbContext())
            {
                return context.TeacherTable.Include(x => x.TeachingSubjects).ToList();

            }
        }


        public Teachers GetTeacher(int ID)
        {
            var context = new dbContext();

            return context.TeacherTable.Find(ID);

        }


        public Teachers GetTeacherdispose(int ID)
        {
            using (var context = new dbContext())
            {

                return context.TeacherTable.Find(ID);
            }
        }



        public void UpdateTeacher(Teachers Teacher)
        {
            using (var context = new dbContext())
            {
                context.Entry(Teacher).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteTeacher(int ID)
        {
            using (var context = new dbContext())
            {
                var Teacher = context.TeacherTable.Find(ID);
                context.TeacherTable.Remove(Teacher);
                context.SaveChanges();
            }
        }

    }
}
