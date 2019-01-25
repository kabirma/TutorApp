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

        public Teachers LoginTeacher(Teachers teacher)
        {
            using(var context=new dbContext())
            {
                Teachers check= context.TeacherTable.Where(x => x.Email.Equals(teacher.Email) || x.Name.Equals(teacher.Name) || x.PhoneNumber.Equals(teacher.PhoneNumber) && x.Password.Equals(teacher.Password)).FirstOrDefault();
                return check;
            }
        }
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
                    return context.TeacherTable.Where(Teacher => Teacher.Name != null && Teacher.Name.ToLower().Contains(Search.ToLower())).OrderBy(Teacher => Teacher.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).ToList();
                }
                else
                {
                    return context.TeacherTable.OrderBy(Teachers => Teachers.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).ToList();
                }
            }
        }

        public List<Teachers> GetTeachers(string Search, int pageNo, string subject,string timeperiod)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.TeacherTable.Where(Teacher => Teacher.Name != null && Teacher.Name.ToLower().Contains(Search.ToLower())).OrderBy(Teacher => Teacher.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Include(x => x.TeachingSubjects.Category).Include(x => x.TeachingSubjects2.Category).Include(x => x.TeachingSubjects3.Category).Include(x => x.TeachingSubjects4.Category).Include(x => x.TeachingSubjects5.Category).ToList();
                }
                if (!string.IsNullOrEmpty(subject))
                {
                    if (subject == "all")
                    {
                        return context.TeacherTable.OrderBy(Teachers => Teachers.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Include(x => x.TeachingSubjects.Category).Include(x => x.TeachingSubjects2.Category).Include(x => x.TeachingSubjects3.Category).Include(x => x.TeachingSubjects4.Category).Include(x => x.TeachingSubjects5.Category).ToList();
                    }
                    else
                    { 
                    return context.TeacherTable.Where(Teacher => Teacher.Name != null && Teacher.TeachingSubjects.Name == subject || Teacher.TeachingSubjects2.Name == subject || Teacher.TeachingSubjects3.Name == subject || Teacher.TeachingSubjects4.Name == subject || Teacher.TeachingSubjects5.Name == subject).OrderBy(Teacher => Teacher.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Include(x => x.TeachingSubjects.Category).Include(x => x.TeachingSubjects2.Category).Include(x => x.TeachingSubjects3.Category).Include(x => x.TeachingSubjects4.Category).Include(x => x.TeachingSubjects5.Category).ToList();
                    }
                }
                if (!string.IsNullOrEmpty(timeperiod))
                {
                    if (timeperiod == "old")
                    {
                        return context.TeacherTable.OrderByDescending(Teachers => Teachers.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Include(x => x.TeachingSubjects.Category).Include(x => x.TeachingSubjects2.Category).Include(x => x.TeachingSubjects3.Category).Include(x => x.TeachingSubjects4.Category).Include(x => x.TeachingSubjects5.Category).ToList();
                    }
                    else
                    {
                        return context.TeacherTable.OrderBy(Teachers => Teachers.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Include(x => x.TeachingSubjects.Category).Include(x => x.TeachingSubjects2.Category).Include(x => x.TeachingSubjects3.Category).Include(x => x.TeachingSubjects4.Category).Include(x => x.TeachingSubjects5.Category).ToList();
                    }
                }
                else
                {
                    return context.TeacherTable.OrderBy(Teachers => Teachers.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Include(x => x.TeachingSubjects.Category).Include(x => x.TeachingSubjects2.Category).Include(x => x.TeachingSubjects3.Category).Include(x => x.TeachingSubjects4.Category).Include(x => x.TeachingSubjects5.Category).ToList();
                }
            }
        }
        //public List<Teachers> GetTeacherTeachers(string Search, int pageNo, int userid)
        //{

        //    using (var context = new dbContext())
        //    {
        //        if (!string.IsNullOrEmpty(Search))
        //        {
        //            return context.TeacherTable.Where(Blog => Blog.Login.ID == userid && Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).OrderBy(Product => Product.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Include(x => x.Login).ToList();
        //        }
        //        else
        //        {
        //            return context.TeacherTable.Where(Blog => Blog.Login.ID == userid).OrderBy(Blog => Blog.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Include(x => x.Login).ToList();
        //        }
        //    }
        //}


        public int GetTeachersCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.TeacherTable.Where(Teacher => Teacher.Name != null && Teacher.Name.ToLower().Contains(Search.ToLower())).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Count();
                }
                else
                {
                    return context.TeacherTable.Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Count();
                }
            }
        }

        public int GetTeachersCount(string Search, string subject)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.TeacherTable.Where(Teacher => Teacher.Name != null && Teacher.Name.ToLower().Contains(Search.ToLower())).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Count();
                }
                if (!string.IsNullOrEmpty(subject))
                {
                    if (subject == "all")
                    {
                        return context.TeacherTable.Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Count();
                    }
                    else
                    {
                        return context.TeacherTable.Where(Teacher => Teacher.Name != null && Teacher.TeachingSubjects.Name == subject || Teacher.TeachingSubjects2.Name == subject || Teacher.TeachingSubjects3.Name == subject || Teacher.TeachingSubjects4.Name == subject || Teacher.TeachingSubjects5.Name == subject).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Count();
                    }
                }
                else
                {
                    return context.TeacherTable.Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Count();
                }
            }
        }
        public int GetTeachersCount()
        {
            using (var context = new dbContext())
            {
                return context.TeacherTable.Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Count();
            }
        }


        //public int GetTeacherTeachersCount(string Search, int userid)
        //{

        //    using (var context = new dbContext())
        //    {
        //        if (!string.IsNullOrEmpty(Search))
        //        {
        //            return context.TeacherTable.Where(Blog => Blog.Login.ID == userid && Blog.Name != null && Blog.Name.ToLower().Contains(Search.ToLower())).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Include(x => x.Login).Count();
        //        }
        //        else
        //        {
        //            return context.TeacherTable.Where(Blog => Blog.Login.ID == userid).Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Include(x => x.Login).Count();
        //        }
        //    }
        //}

        public List<Teachers> GetTeachers()
        {
            using (var context = new dbContext())
            {
                return context.TeacherTable.Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).ToList();

            }
        }


        public Teachers GetTeacher(int ID)
        {
            var context = new dbContext();

            return context.TeacherTable.Include(x => x.TeachingSubjects).Include(x => x.TeachingSubjects2).Include(x => x.TeachingSubjects3).Include(x => x.TeachingSubjects4).Include(x => x.TeachingSubjects5).Include(x => x.TeachingSubjects.Category).Include(x => x.TeachingSubjects2.Category).Include(x => x.TeachingSubjects3.Category).Include(x => x.TeachingSubjects4.Category).Include(x => x.TeachingSubjects5.Category).SingleOrDefault(x => x.ID == ID);

        }


        public Teachers GetTeacherdispose(int ID)
        {
            using (var context = new dbContext())
            {

                return context.TeacherTable.Include(x=>x.TeachingSubjects).SingleOrDefault(x => x.ID == ID);
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
