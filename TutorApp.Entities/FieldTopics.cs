using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.Entities
{
    public class FieldTopics : BaseEntity
    {
        public string Description { get; set; }
        public CoursesField Category { get; set; }
    }
}
