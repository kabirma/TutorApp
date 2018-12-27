using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.Entities
{
    public class CoursesField : BaseEntity
    {
        public string Description { get; set; }
        public Courses Category { get; set; }
    }
}

