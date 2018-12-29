using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class TopicDetailSearchViewModel
    {
        public List<TopicDetails> TopicDetail { get; set; }
        public string Search { get; set; }
        public Pager Pager { get; internal set; }
    }
    public class NewTopicDetailViewModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imageurl { get; set; }

        public int CategoryID { get; set; }
        public List<FieldTopics> Categories { get; set; }

    }
}