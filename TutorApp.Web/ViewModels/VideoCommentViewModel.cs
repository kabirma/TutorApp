using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class VideoCommentSearchViewModel
    {
        public List<VideoComments> VideoComment { get; set; }
        public string Search { get; internal set; }
        public Pager Pager { get; internal set; }
    }

    public class NewVideoCommentViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
      
        public int VideosID { get; set; }
        public List<Videos> Videos { get; set; }

        public string Date { get; set; }
    }
}