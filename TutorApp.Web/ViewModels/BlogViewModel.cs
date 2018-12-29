using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class BlogViewModel
    {
        public List<Blogs> Blogs { get; set; }
        public string Search { get; set; }
        public Pager Pager { get; internal set; }
    }

    public class NewBlogViewModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Date { get; set; }

        public int WriterID { get; set; }
        public List<Teachers> Writer { get; set; }

        public int CategoryID { get; set; }
        public List<Courses> Category { get; set; }

        public int Category2ID { get; set; }
        public List<Courses> Category2 { get; set; }

        public int Category3ID { get; set; }
        public List<Courses> Category3 { get; set; }

        public int Category4ID { get; set; }
        public List<Courses> Category4 { get; set; }

        public int Category5ID { get; set; }
        public List<Courses> Category5 { get; set; }


    }
}