using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class ListViewModel
    {
        public List<CompanyDetails> CompanyDetail { get; set; }
        public List<VideosCategory> VideoCategory { get; set; }
        public List<Videos> Videos { get; set; }
        public Videos Video { get; set; }
        public List<VideoComments> Comments { get; set; }
        public int CommentCount { get; set; }
        public List<Teachers> Teachers { get; set; }
        public Teachers Teacher { get; set; }

        public List<Courses> Courses { get; set; }

        public List<Students> Student { get; set; }
        public Students SingleStudent { get; set; }

        public List<CoursesField> CourseField { get; set; }
        public CoursesField SingleCourseField { get; set; }

        public List<FieldTopics> TopicField { get; set; }
        public FieldTopics SingleTopicField { get; set; }
        public List<TopicDetails> TopicDetail { get; set; }

        public List<Questions> Question { get; set; }
        public Questions SingleQuestion { get; set; }
        public List<Answers> Answer { get; set; }
        public List<FilesCategory> FileCategory { get; set; }
        public int TeacherCount { get; set; }
        public int StudentCount { get; set; }
        public List<Accounts> Admin { get; set; }
        public int AdminCount { get; set; }


        public int VideoCount { get; set; }

        public int QuestionCount { get; set; }

        public int FilesCount { get; set; }

        public int CoursesCount { get; set; }
        public int CourseFieldCount { get; set; }
        public int FieldTopicCount { get; set; }

        public int InboxCount { get; set; }
        public int JobsCount { get; set; }
        public List<Inbox> Inbox { get; set; }

        public List<Jobs> Job { get; set; }
        public List<Files> Files { get; set; }
        public string Search { get; internal set; }
        public Pager Pager { get; internal set; }
        public string Message { get; internal set; }
    }
}