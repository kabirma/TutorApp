using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class ListViewModel
    {
      
        public List<Teachers> Teacher { get; set; }

        public List<Courses> Courses { get; set; }

        public List<Students> Student { get; set; }

        public List<CoursesField> CourseField { get; set; }

        public List<FieldTopics> TopicField { get; set; }


        public List<Questions> Question { get; set; }
        public List<FilesCategory> FileCategory { get; set; }
    }
}