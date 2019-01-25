using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class JobSearchViewModel
    {
        public List<Jobs> Job { get; set; }
        public string Search { get; set; }
        public Pager Pager { get; internal set; }
    }

    public class NewJobViewModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string ZipCode { get; set; }
        public string Location { get; set; }
      
        public string GradingLevel { get; set; }
        public string Availability { get; set; }
        public string Date { get; set; }
        public string LessonBegins { get; set; }

        public int CourseID { get; set; }
        public List<Courses> Subject { get; set; }


        public int StudentID { get; set; }
        public List<Students> Student { get; set; }

    }
}