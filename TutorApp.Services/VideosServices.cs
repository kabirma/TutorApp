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
    public class VideosServices
    {

        #region singleton
        public static VideosServices Instance
        {
            get
            {
                if (instance == null) instance = new VideosServices();
                return instance;
            }
        }
        private static VideosServices instance { get; set; }
        private VideosServices()
        {

        }
        #endregion
        public void SaveVideos(Videos Video)
        {

            using (var context = new dbContext())
            {
                context.Entry(Video.Writer).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(Video.Category).State = System.Data.Entity.EntityState.Unchanged;

                context.VideoTable.Add(Video);
                context.SaveChanges();
            }
        }
        int items = 20;
        public List<Videos> GetVideos(string Search, int pageNo)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.VideoTable.Where(Video => Video.Name != null && Video.Name.ToLower().Contains(Search.ToLower())).OrderBy(Video => Video.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                }
                else
                {
                    return context.VideoTable.OrderBy(Videos => Videos.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                }
            }
        }

        public List<Videos> GetVideos(string Search, int pageNo, string Writer, string Category,string timeperiod)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.VideoTable.Where(Video => Video.Name != null && Video.Name.ToLower().Contains(Search.ToLower())).OrderBy(Video => Video.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                }
                if (!string.IsNullOrEmpty(Writer))
                {
                    if (Writer == "all")
                    {
                        return context.VideoTable.OrderBy(Videos => Videos.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                    }
                    else
                    {
                        return context.VideoTable.Where(video => video.Name != null && video.Writer.Name == Writer).OrderBy(video => video.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                    }
                }

                if (!string.IsNullOrEmpty(Category))
                {
                    if (Category == "all")
                    {
                        return context.VideoTable.OrderBy(Videos => Videos.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                    }
                    else
                    {
                        return context.VideoTable.Where(video => video.Name != null && video.Category.Name == Category).OrderBy(video => video.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                    }
                }

                if (!string.IsNullOrEmpty(timeperiod))
                {
                    if (timeperiod == "old")
                    {
                        return context.VideoTable.OrderByDescending(video => video.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                    }
                    else
                    {
                        return context.VideoTable.OrderBy(video => video.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();

                    }
                }
                else
                {
                    return context.VideoTable.OrderBy(Videos => Videos.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                }
            }
        }
        public List<Videos> GetTeacherVideos(string Search, int pageNo, int userid)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.VideoTable.Where(Video => Video.Writer.ID == userid && Video.Name != null && Video.Name.ToLower().Contains(Search.ToLower())).OrderBy(Product => Product.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                }
                else
                {
                    return context.VideoTable.Where(Video => Video.Writer.ID == userid).OrderBy(Video => Video.ID).Skip((pageNo - 1) * items).Take(items).Include(x => x.Writer).Include(x => x.Category).ToList();
                }
            }
        }


        public int GetVideosCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.VideoTable.Where(Video => Video.Name != null && Video.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Writer).Include(x => x.Category).Count();
                }
                else
                {
                    return context.VideoTable.Include(x => x.Writer).Include(x => x.Category).Count();
                }
            }
        }

        public int GetVideosCount(string Search, string Writer, string Category)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.VideoTable.Where(Video => Video.Name != null && Video.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Writer).Include(x => x.Category).Count();
                }
                if (!string.IsNullOrEmpty(Writer))
                {
                    return context.VideoTable.Where(Video => Video.Name != null && Video.Writer.Name == Writer).Include(x => x.Writer).Include(x => x.Category).Count();
                }

                if (!string.IsNullOrEmpty(Category))
                {
                    return context.VideoTable.Where(Video => Video.Name != null && Video.Category.Name == Writer).Include(x => x.Writer).Include(x => x.Category).Count();
                }
                else
                {
                    return context.VideoTable.Include(x => x.Writer).Include(x => x.Category).Count();
                }
            }
        }
        public int GetVideosCount()
        {
            using (var context = new dbContext())
            {
                return context.VideoTable.Include(x => x.Writer).Include(x => x.Category).Count();
            }
        }


        public int GetTeacherVideosCount(string Search, int userid)
        {

            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.VideoTable.Where(Video => Video.Writer.ID == userid && Video.Name != null && Video.Name.ToLower().Contains(Search.ToLower())).Include(x => x.Writer).Include(x => x.Category).Count();
                }
                else
                {
                    return context.VideoTable.Where(Video => Video.Writer.ID == userid).Include(x => x.Writer).Include(x => x.Category).Count();
                }
            }
        }

        public List<Videos> GetVideos()
        {
            using (var context = new dbContext())
            {
                return context.VideoTable.Include(x => x.Writer).Include(x => x.Category).ToList();

            }
        }


        public Videos GetVideo(int ID)
        {
            var context = new dbContext();

            return context.VideoTable.Include(x => x.Writer).Include(x => x.Category).SingleOrDefault(x => x.ID == ID);

        }


        public Videos GetVideodispose(int ID)
        {
            using (var context = new dbContext())
            {

                return context.VideoTable.Include(x => x.Writer).Include(x => x.Category).SingleOrDefault(x => x.ID == ID);
            }
        }



        public void UpdateVideo(Videos Video)
        {
            using (var context = new dbContext())
            {
                context.Entry(Video).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteVideo(int ID)
        {
            using (var context = new dbContext())
            {
                var Video = context.VideoTable.Find(ID);
                context.VideoTable.Remove(Video);
                context.SaveChanges();
            }
        }


    }
}
