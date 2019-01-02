using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class QuestionSearchViewModel
    {
        public List<Questions> Question { get; set; }
        public string Search { get; set; }
        public Pager Pager { get; internal set; }
    }

    public class NewQuestionViewModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public int SubjectID { get; set; }
        public List<Courses> Subject { get; set; }


        public int StudentID { get; set; }
        public List<Students> Student { get; set; }

    }
}