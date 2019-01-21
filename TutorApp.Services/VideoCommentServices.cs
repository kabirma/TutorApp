using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Database;
using TutorApp.Entities;

namespace TutorApp.Services
{
    public class VideoCommentServices
    {
        #region singleton
        public static VideoCommentServices Instance
        {
            get
            {
                if (instance == null) instance = new VideoCommentServices();
                return instance;
            }
        }
        private static VideoCommentServices instance { get; set; }
        private VideoCommentServices()
        {

        }
        #endregion



        public List<VideoComments> GetVideoComments()
        {
            using (var context = new dbContext())
            {
                return context.VideoCommentTable.ToList();
            }
        }

        public int GetVideoCommentsCount()
        {
            using (var context = new dbContext())
            {
                return context.VideoCommentTable.Count();
            }
        }

        public VideoComments GetVideoComment(int ID)
        {
            using (var context = new dbContext())
            {
                return context.VideoCommentTable.Find(ID);
            }
        }

        public void SaveVideoComments(VideoComments VideoComments)
        {
            using (var context = new dbContext())
            {
                context.VideoCommentTable.Add(VideoComments);
                context.SaveChanges();
            }
        }

        public void UpdateVideoComments(VideoComments VideoCommentss)
        {
            using (var context = new dbContext())
            {
                context.Entry(VideoCommentss).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteVideoComments(int ID)
        {
            using (var context = new dbContext())
            {
                var VideoComments = context.VideoCommentTable.Find(ID);
                context.VideoCommentTable.Remove(VideoComments);
                context.SaveChanges();
            }
        }


        public List<VideoComments> GetVideoComments(string Search, int pageNo)
        {
            int items = 3;
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.VideoCommentTable.Where(VideoComments => VideoComments.Name != null && VideoComments.Name.ToLower().Contains(Search.ToLower())).OrderBy(VideoComments => VideoComments.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
                else
                {
                    return context.VideoCommentTable.OrderBy(VideoComment => VideoComment.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
            }
        }

        public List<VideoComments> GetSelectedVideoComments(int ID)
        {
           
            using (var context = new dbContext())
            {
               
                if (ID > 0)
                {
                    return context.VideoCommentTable.OrderBy(VideoComment => VideoComment.ID).Where(x=>x.Video.ID==ID).ToList();

                }
                else
                {
                    return context.VideoCommentTable.OrderBy(VideoComment => VideoComment.ID).ToList();
                }
            }
        }

        public int GetVideoCommentsCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    int count = context.VideoCommentTable.Where(VideoComments => VideoComments.Name != null && VideoComments.Name.ToLower().Contains(Search.ToLower())).Count();
                    return count;
                }
                else
                {
                    return context.VideoCommentTable.Count();
                }
            }
        }
    }
}
