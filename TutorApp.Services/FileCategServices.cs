using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Database;
using TutorApp.Entities;

namespace TutorApp.Services
{
    public class FileCategServices
    {

        #region singleton
        public static FileCategServices Instance
        {
            get
            {
                if (instance == null) instance = new FileCategServices();
                return instance;
            }
        }
        private static FileCategServices instance { get; set; }
        private FileCategServices()
        {

        }

        #endregion
        public void SaveFilesCategory(FilesCategory FileCategory)
        {

            using (var context = new dbContext())
            {

                context.FilesCategoryTable.Add(FileCategory);
                context.SaveChanges();
            }
        }

        public List<FilesCategory> GetFilesCategory(string Search, int pageNo)
        {
            int items = 3;
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.FilesCategoryTable.Where(File => File.Name != null && File.Name.ToLower().Contains(Search.ToLower())).OrderBy(File => File.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
                else
                {
                    return context.FilesCategoryTable.OrderBy(File => File.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
            }
        }
        public List<FilesCategory> GetFilesCategory()
        {
            using (var context = new dbContext())
            {
                return context.FilesCategoryTable.ToList();
            }
        }

        public int GetFilesCategoryCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.FilesCategoryTable.Where(a => a.Name != null && a.Name.ToLower().Contains(Search.ToLower())).Count();
                }
                else
                {
                    return context.FilesCategoryTable.Count();
                }
            }
        }


        public FilesCategory GetFileCateg(int ID)
        {
            using (var context = new dbContext())
            { return context.FilesCategoryTable.Find(ID); }
        }

        public void UpdateFilesCategory(FilesCategory FileCategory)
        {

            using (var context = new dbContext())
            {
                context.Entry(FileCategory).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteFilesCategory(int ID)
        {
            using (var context = new dbContext())
            {
                var FileCategory = context.FilesCategoryTable.Find(ID);

                context.FilesCategoryTable.Remove(FileCategory);

                context.SaveChanges();

            }
        }

    }
}
