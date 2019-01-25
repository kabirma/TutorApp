using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.Entities
{
    public class Jobs : BaseEntity
    {
        public string ZipCode { get; set; }
        public Students Student { get; set; }
        public string Location { get; set; }
        public Courses Course { get; set; }
        public string GradingLevel { get; set; }
        public string Availability { get; set; }
        public string Date { get; set; }
        public string LessonBegins { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
    }
}
