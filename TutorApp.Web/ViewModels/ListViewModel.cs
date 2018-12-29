using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class ListViewModel
    {
        public List<Courses> BlogCategory { get; set; }
        public List<Courses> BlogCategory2 { get; set; }
        public List<Courses> BlogCategory3 { get; set; }
        public List<Courses> BlogCategory4 { get; set; }
        public List<Courses> BlogCategory5 { get; set; }

        public List<Teachers> Writer { get; set; }
    }
}