using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.Entities
{
    public class TopicDetails : BaseEntity
    {
        public string Description { get; set; }
        public FieldTopics Category { get; set; }
        public string Imageurl { get; set; }
    }
}
