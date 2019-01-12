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
    public class FilesServices
    {


        #region singleton
        public static FilesServices Instance
        {
            get
            {
                if (instance == null) instance = new FilesServices();
                return instance;
            }
        }
        private static FilesServices instance { get; set; }
        private FilesServices()
        {

        }
        #endregion
        public void SaveFiles(Files File)
        {

            using (var context = new dbContext())
            {
                context.Entry(File.Writer).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(File.Category).State = System.Data.Entity.EntityState.Unchanged;

                context.FileTable.Add(File);
                context.SaveChanges();
            }
        }
        int items = 20;
        public List<Files> GetFiles(string Search, int pageNo)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.FileTable.Where(File => File.Name != null && File.Name.ToLower().Contains(Search.ToLower())).OrderBy(File => File.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                }
                else
                {
                    return context.FileTable.OrderBy(Files => Files.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                }
            }
        }

        public List<Files> GetFiles(string Search, int pageNo, string Category, string Writer,string timeperiod)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.FileTable.Where(File => File.Name != null && File.Name.ToLower().Contains(Search.ToLower())).OrderBy(File => File.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                }
                if (!string.IsNullOrEmpty(Writer))
                {
                    if (Writer == "all") {
                        return context.FileTable.OrderBy(Files => Files.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                    }
                    else
                    {
                        return context.FileTable.Where(File => File.Name != null && File.Writer.Name == Writer).OrderBy(File => File.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                    }
                }
                if (!string.IsNullOrEmpty(Category))
                {
                    if (Category == "all") {
                        return context.FileTable.OrderBy(Files => Files.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                    }
                    else
                    {
                        return context.FileTable.Where(File => File.Name != null && File.Category.Name == Category).OrderBy(File => File.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                    }
                }
                if (!string.IsNullOrEmpty(timeperiod)) {
                    if (timeperiod == "old")
                    {
                        return context.FileTable.OrderByDescending(Files => Files.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                    }
                    else
                    {
                        return context.FileTable.OrderBy(Files => Files.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();

                    }
                }
                else
                {
                    return context.FileTable.OrderBy(Files => Files.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                }
            }
        }
        public List<Files> GetTeacherFiles(string Search, int pageNo, int userid)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.FileTable.Where(File => File.Writer.ID == userid && File.Name != null && File.Name.ToLower().Contains(Search.ToLower())).OrderBy(Product => Product.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                }
                else
                {
                    return context.FileTable.Where(File => File.Writer.ID == userid).OrderBy(File => File.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                }
            }
        }


        public int GetFilesCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.FileTable.Where(File => File.Name != null && File.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Writer).Include(x => x.Category).Count();
                }
                else
                {
                    return context.FileTable.Include(x => x.Writer).Include(x => x.Category).Count();
                }
            }
        }

        public int GetFilesCount(string Search, string Category, string Writer)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.FileTable.Where(File => File.Name != null && File.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Writer).Include(x => x.Category).Count();
                }
                if (!string.IsNullOrEmpty(Writer))
                {
                    if (Writer == "all") { return context.FileTable.Include(x => x.Writer).Include(x => x.Category).Count(); }
                    else {
                        return context.FileTable.Where(File => File.Name != null && File.Writer.Name == Writer).Include(x => x.Writer).Include(x => x.Category).Count();
                    }
                }

                if (!string.IsNullOrEmpty(Category))
                {
                    if (Category == "all") { return context.FileTable.Include(x => x.Writer).Include(x => x.Category).Count(); }
                    else
                    {
                        return context.FileTable.Where(File => File.Name != null && File.Category.Name == Category).Include(x => x.Writer).Include(x => x.Category).Count();
                    }
                }
                else
                {
                    return context.FileTable.Include(x => x.Writer).Include(x => x.Category).Count();
                }
            }
        }
        public int GetFilesCount()
        {
            using (var context = new dbContext())
            {
                return context.FileTable.Include(x => x.Writer).Include(x => x.Category).Count();
            }
        }


        public int GetTeacherFilesCount(string Search, int userid)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.FileTable.Where(File => File.Writer.ID == userid && File.Name != null && File.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Writer).Include(x => x.Category).Count();
                }
                else
                {
                    return context.FileTable.Where(File => File.Writer.ID == userid).Include(x => x.Writer).Include(x => x.Category).Count();
                }
            }
        }

        public List<Files> GetFiles()
        {
            using (var context = new dbContext())
            {
                return context.FileTable.Include(x => x.Writer).Include(x => x.Category).ToList();

            }
        }


        public Files GetFile(int ID)
        {
            var context = new dbContext();

            return context.FileTable.Include(x => x.Writer).Include(x => x.Category).SingleOrDefault(x => x.ID == ID);

        }


        public Files GetFiledispose(int ID)
        {
            using (var context = new dbContext())
            {

                return context.FileTable.Include(x => x.Writer).Include(x => x.Category).SingleOrDefault(x => x.ID == ID);
            }
        }



        public void UpdateFile(Files File)
        {
            using (var context = new dbContext())
            {
                context.Entry(File).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteFile(int ID)
        {
            using (var context = new dbContext())
            {
                var File = context.FileTable.Find(ID);
                context.FileTable.Remove(File);
                context.SaveChanges();
            }
        }


    }
}
