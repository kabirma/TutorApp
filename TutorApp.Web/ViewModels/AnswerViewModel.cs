using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class AnswerSearchViewModel
    {
        public List<Answers> Answer { get; set; }
        public string Search { get; set; }
        public Pager Pager { get; internal set; }
    }

    public class NewAnswerViewModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public string Upvote { get; set; }
        public string Downvote { get; set; }
        public int AnsweredByID { get; set; }
        public List<Teachers> AnsweredBy { get; set; }


        public int QuestionID { get; set; }
        public List<Questions> Question { get; set; }

    }
}