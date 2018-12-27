using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.Entities
{
    public class Answers : BaseEntity
    {
        public string Description { get; set; }
        public Teachers AnsweredBy { get; set; }
        public string Date { get; set; }
        public Questions Question { get; set; }
        public string Upvote { get; set; }
        public string Downvote { get; set; }

    }
}
