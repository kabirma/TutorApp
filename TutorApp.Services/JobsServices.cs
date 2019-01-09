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
    public class JobsServices
    {
        #region singleton
        public static JobsServices Instance
        {
            get
            {
                if (instance == null) instance = new JobsServices();
                return instance;
            }
        }
        private static JobsServices instance { get; set; }
        private JobsServices()
        {

        }
        #endregion
        public void SaveJobs(Jobs Job)
        {

            using (var context = new dbContext())
            {
                context.Entry(Job.Student).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(Job.Course).State = System.Data.Entity.EntityState.Unchanged;

                context.JobTable.Add(Job);
                context.SaveChanges();
            }
        }
        int items = 20;
        public List<Jobs> GetJobs(string Search, int pageNo)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.JobTable.Where(Job => Job.Name != null && Job.Name.ToLower().Contains(Search.ToLower())).OrderBy(Job => Job.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Student).Include(x => x.Course).ToList();
                }
                else
                {
                    return context.JobTable.OrderBy(Jobs => Jobs.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Student).Include(x => x.Course).ToList();
                }
            }
        }

        public List<Jobs> GetJobs(string Search, int pageNo, string Student, string Course)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.JobTable.Where(Job => Job.Name != null && Job.Name.ToLower().Contains(Search.ToLower())).OrderBy(Job => Job.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Student).Include(x => x.Course).ToList();
                }
                if (!string.IsNullOrEmpty(Student))
                {
                    return context.JobTable.Where(Job => Job.Name != null && Job.Student.Name == Student).OrderBy(Job => Job.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Student).Include(x => x.Course).ToList();
                }
                if (!string.IsNullOrEmpty(Course))
                {
                    return context.JobTable.Where(Job => Job.Name != null && Job.Course.Name == Course).OrderBy(Job => Job.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Student).Include(x => x.Course).ToList();
                }
                else
                {
                    return context.JobTable.OrderBy(Jobs => Jobs.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Student).Include(x => x.Course).ToList();
                }
            }
        }
        public List<Jobs> GetStudentJobs(string Search, int pageNo, int userid)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.JobTable.Where(Job => Job.Student.ID == userid && Job.Name != null && Job.Name.ToLower().Contains(Search.ToLower())).OrderBy(Product => Product.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Student).Include(x => x.Course).ToList();
                }
                else
                {
                    return context.JobTable.Where(Job => Job.Student.ID == userid).OrderBy(Job => Job.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Student).Include(x => x.Course).ToList();
                }
            }
        }


        public int GetJobsCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.JobTable.Where(Job => Job.Name != null && Job.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Student).Include(x => x.Course).Count();
                }
                else
                {
                    return context.JobTable.Include(x => x.Student).Include(x => x.Course).Count();
                }
            }
        }

        public int GetJobsCount(string Search, string Student, string Course)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.JobTable.Where(Job => Job.Name != null && Job.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Student).Include(x => x.Course).Count();
                }
                if (!string.IsNullOrEmpty(Student))
                {
                    return context.JobTable.Where(Job => Job.Name != null && Job.Student.Name == Student).Include(x => x.Student).Include(x => x.Course).Count();
                }

                if (!string.IsNullOrEmpty(Course))
                {
                    return context.JobTable.Where(Job => Job.Name != null && Job.Course.Name == Student).Include(x => x.Student).Include(x => x.Course).Count();
                }
                else
                {
                    return context.JobTable.Include(x => x.Student).Include(x => x.Course).Count();
                }
            }
        }
        public int GetJobsCount()
        {
            using (var context = new dbContext())
            {
                return context.JobTable.Include(x => x.Student).Include(x => x.Course).Count();
            }
        }


        public int GetStudentJobsCount(string Search, int userid)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.JobTable.Where(Job => Job.Student.ID == userid && Job.Name != null && Job.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Student).Include(x => x.Course).Count();
                }
                else
                {
                    return context.JobTable.Where(Job => Job.Student.ID == userid).Include(x => x.Student).Include(x => x.Course).Count();
                }
            }
        }

        public List<Jobs> GetJobs()
        {
            using (var context = new dbContext())
            {
                return context.JobTable.Include(x => x.Student).Include(x => x.Course).ToList();

            }
        }


        public Jobs GetJob(int ID)
        {
            var context = new dbContext();

            return context.JobTable.Include(x => x.Student).Include(x => x.Course).SingleOrDefault(x => x.ID == ID);

        }


        public Jobs GetJobdispose(int ID)
        {
            using (var context = new dbContext())
            {

                return context.JobTable.Include(x => x.Student).Include(x => x.Course).SingleOrDefault(x => x.ID == ID);
            }
        }



        public void UpdateJob(Jobs Job)
        {
            using (var context = new dbContext())
            {
                context.Entry(Job).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteJob(int ID)
        {
            using (var context = new dbContext())
            {
                var Job = context.JobTable.Find(ID);
                context.JobTable.Remove(Job);
                context.SaveChanges();
            }
        }
    }
}
