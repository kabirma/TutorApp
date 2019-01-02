using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Database;
using TutorApp.Entities;

namespace TutorApp.Services
{
    public class VideoCategServices
    {
        #region singleton
        public static VideoCategServices Instance
        {
            get
            {
                if (instance == null) instance = new VideoCategServices();
                return instance;
            }
        }
        private static VideoCategServices instance { get; set; }
        private VideoCategServices()
        {

        }

        #endregion
        public void SaveVideosCategory(VideosCategory VideoCategory)
        {

            using (var context = new dbContext())
            {

                context.VideoCategoryTable.Add(VideoCategory);
                context.SaveChanges();
            }
        }

        public List<VideosCategory> GetVideosCategory(string Search, int pageNo)
        {
            int items = 3;
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.VideoCategoryTable.Where(VideoCateg => VideoCateg.Name != null && VideoCateg.Name.ToLower().Contains(Search.ToLower())).OrderBy(VideoCateg => VideoCateg.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
                else
                {
                    return context.VideoCategoryTable.OrderBy(VideoCateg => VideoCateg.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
            }
        }
        public List<VideosCategory> GetVideosCategory()
        {
            using (var context = new dbContext())
            {
                return context.VideoCategoryTable.ToList();
            }
        }

        public int GetVideosCategoryCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.VideoCategoryTable.Where(a => a.Name != null && a.Name.ToLower().Contains(Search.ToLower())).Count();
                }
                else
                {
                    return context.VideoCategoryTable.Count();
                }
            }
        }


        public VideosCategory GetVideoCateg(int ID)
        {
            using (var context = new dbContext())
            { return context.VideoCategoryTable.Find(ID); }
        }

        public void UpdateVideosCategory(VideosCategory VideoCategory)
        {

            using (var context = new dbContext())
            {
                context.Entry(VideoCategory).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteVideosCategory(int ID)
        {
            using (var context = new dbContext())
            {
                var VideoCategory = context.VideoCategoryTable.Find(ID);

                context.VideoCategoryTable.Remove(VideoCategory);

                context.SaveChanges();

            }
        }

    }
}
