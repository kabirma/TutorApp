using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class CourseFieldSearchViewModel
    {
        public List<CoursesField> CourseField { get; set; }
        public string Search { get; set; }
        public Pager Pager { get; internal set; }
    }

    public class NewCourseFieldViewModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public List<Courses> Categories { get; set; }
       
    }
}