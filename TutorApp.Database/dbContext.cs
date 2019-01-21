using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Entity;
using System.Data.Entity;
using TutorApp.Entities;

namespace TutorApp.Database
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class dbContext : DbContext, IDisposable
    {
        public dbContext() : base("AppDatabase") { }

        public DbSet<Students> StudentTable { get; set;}
        public DbSet<Teachers> TeacherTable { get; set; }
        public DbSet<Accounts> AccountTable { get; set; }
        public DbSet<Blogs> BlogTable { get; set; }
        public DbSet<Courses> CourseTable { get; set; }
        public DbSet<CoursesField> CourseFiledTable { get; set; }
        public DbSet<FieldTopics> FieldTopicTable { get; set; }
        public DbSet<TopicDetails> TopicDetailTable { get; set; }
        public DbSet<Videos> VideoTable { get; set; }
        public DbSet<VideosCategory> VideoCategoryTable { get; set; }

        public DbSet<Files> FileTable { get; set; }
        public DbSet<FilesCategory> FilesCategoryTable { get; set; }
        public DbSet<Questions> QuestionTable { get; set; }
        public DbSet<Answers> AnswerTable { get; set; }

        public DbSet<Jobs> JobTable { get; set; }
        public DbSet<Inbox> InboxTable { get; set; }
        public DbSet<CompanyDetails> CompanyDetailsTable { get; set; }
        public DbSet<VideoComments> VideoCommentTable { get; set; }
    }
}
