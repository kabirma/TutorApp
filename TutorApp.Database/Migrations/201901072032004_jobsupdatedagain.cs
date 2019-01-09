namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobsupdatedagain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        Date = c.String(unicode: false),
                        Upvote = c.String(unicode: false),
                        Downvote = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        AnsweredBy_ID = c.Int(),
                        Question_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teachers", t => t.AnsweredBy_ID)
                .ForeignKey("dbo.Questions", t => t.Question_ID)
                .Index(t => t.AnsweredBy_ID)
                .Index(t => t.Question_ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LName = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        IsTeacher = c.Boolean(nullable: false),
                        Experience = c.String(unicode: false),
                        StudentType = c.String(unicode: false),
                        LessonLocation = c.String(unicode: false),
                        AvailableHours = c.String(unicode: false),
                        Gender = c.String(unicode: false),
                        DOB = c.String(unicode: false),
                        UndergraduateCollage = c.String(unicode: false),
                        UndergraduateMajor = c.String(unicode: false),
                        GraduateCollage = c.String(unicode: false),
                        GraduateDegree = c.String(unicode: false),
                        GraduateCollage2 = c.String(unicode: false),
                        GraduateDegree2 = c.String(unicode: false),
                        HoulryRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PhoneNumber = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        City = c.String(unicode: false),
                        State = c.String(unicode: false),
                        Country = c.String(unicode: false),
                        ZipCode = c.String(unicode: false),
                        Bio = c.String(unicode: false),
                        ImageUrl = c.String(unicode: false),
                        Facebook = c.String(unicode: false),
                        Twitter = c.String(unicode: false),
                        Google = c.String(unicode: false),
                        Linkedin = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        TeachingSubjects_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CoursesFields", t => t.TeachingSubjects_ID)
                .Index(t => t.TeachingSubjects_ID);
            
            CreateTable(
                "dbo.CoursesFields",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Imageurl = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        Date = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Askedby_ID = c.Int(),
                        Subject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.Askedby_ID)
                .ForeignKey("dbo.Courses", t => t.Subject_ID)
                .Index(t => t.Askedby_ID)
                .Index(t => t.Subject_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        ZipCode = c.String(unicode: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        Date = c.String(unicode: false),
                        Imageurl = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Category_ID = c.Int(),
                        Category2_ID = c.Int(),
                        Category3_ID = c.Int(),
                        Category4_ID = c.Int(),
                        Category5_ID = c.Int(),
                        Writer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.Category_ID)
                .ForeignKey("dbo.Courses", t => t.Category2_ID)
                .ForeignKey("dbo.Courses", t => t.Category3_ID)
                .ForeignKey("dbo.Courses", t => t.Category4_ID)
                .ForeignKey("dbo.Courses", t => t.Category5_ID)
                .ForeignKey("dbo.Teachers", t => t.Writer_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Category2_ID)
                .Index(t => t.Category3_ID)
                .Index(t => t.Category4_ID)
                .Index(t => t.Category5_ID)
                .Index(t => t.Writer_ID);
            
            CreateTable(
                "dbo.FieldTopics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CoursesFields", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.FilesCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        Date = c.String(unicode: false),
                        FilePath = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Category_ID = c.Int(),
                        Writer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FilesCategories", t => t.Category_ID)
                .ForeignKey("dbo.Teachers", t => t.Writer_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Writer_ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Location = c.String(unicode: false),
                        GradingLevel = c.String(unicode: false),
                        Availability = c.String(unicode: false),
                        Date = c.String(unicode: false),
                        LessonBegins = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Course_ID = c.Int(),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.Course_ID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .Index(t => t.Course_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.TopicDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        Imageurl = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FieldTopics", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.VideosCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        Date = c.String(unicode: false),
                        FilePath = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Category_ID = c.Int(),
                        Writer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VideosCategories", t => t.Category_ID)
                .ForeignKey("dbo.Teachers", t => t.Writer_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Writer_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "Writer_ID", "dbo.Teachers");
            DropForeignKey("dbo.Videos", "Category_ID", "dbo.VideosCategories");
            DropForeignKey("dbo.TopicDetails", "Category_ID", "dbo.FieldTopics");
            DropForeignKey("dbo.Jobs", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Jobs", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.Files", "Writer_ID", "dbo.Teachers");
            DropForeignKey("dbo.Files", "Category_ID", "dbo.FilesCategories");
            DropForeignKey("dbo.FieldTopics", "Category_ID", "dbo.CoursesFields");
            DropForeignKey("dbo.Blogs", "Writer_ID", "dbo.Teachers");
            DropForeignKey("dbo.Blogs", "Category5_ID", "dbo.Courses");
            DropForeignKey("dbo.Blogs", "Category4_ID", "dbo.Courses");
            DropForeignKey("dbo.Blogs", "Category3_ID", "dbo.Courses");
            DropForeignKey("dbo.Blogs", "Category2_ID", "dbo.Courses");
            DropForeignKey("dbo.Blogs", "Category_ID", "dbo.Courses");
            DropForeignKey("dbo.Answers", "Question_ID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Subject_ID", "dbo.Courses");
            DropForeignKey("dbo.Questions", "Askedby_ID", "dbo.Students");
            DropForeignKey("dbo.Answers", "AnsweredBy_ID", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "TeachingSubjects_ID", "dbo.CoursesFields");
            DropForeignKey("dbo.CoursesFields", "Category_ID", "dbo.Courses");
            DropIndex("dbo.Videos", new[] { "Writer_ID" });
            DropIndex("dbo.Videos", new[] { "Category_ID" });
            DropIndex("dbo.TopicDetails", new[] { "Category_ID" });
            DropIndex("dbo.Jobs", new[] { "Student_ID" });
            DropIndex("dbo.Jobs", new[] { "Course_ID" });
            DropIndex("dbo.Files", new[] { "Writer_ID" });
            DropIndex("dbo.Files", new[] { "Category_ID" });
            DropIndex("dbo.FieldTopics", new[] { "Category_ID" });
            DropIndex("dbo.Blogs", new[] { "Writer_ID" });
            DropIndex("dbo.Blogs", new[] { "Category5_ID" });
            DropIndex("dbo.Blogs", new[] { "Category4_ID" });
            DropIndex("dbo.Blogs", new[] { "Category3_ID" });
            DropIndex("dbo.Blogs", new[] { "Category2_ID" });
            DropIndex("dbo.Blogs", new[] { "Category_ID" });
            DropIndex("dbo.Questions", new[] { "Subject_ID" });
            DropIndex("dbo.Questions", new[] { "Askedby_ID" });
            DropIndex("dbo.CoursesFields", new[] { "Category_ID" });
            DropIndex("dbo.Teachers", new[] { "TeachingSubjects_ID" });
            DropIndex("dbo.Answers", new[] { "Question_ID" });
            DropIndex("dbo.Answers", new[] { "AnsweredBy_ID" });
            DropTable("dbo.Videos");
            DropTable("dbo.VideosCategories");
            DropTable("dbo.TopicDetails");
            DropTable("dbo.Jobs");
            DropTable("dbo.Files");
            DropTable("dbo.FilesCategories");
            DropTable("dbo.FieldTopics");
            DropTable("dbo.Blogs");
            DropTable("dbo.Students");
            DropTable("dbo.Questions");
            DropTable("dbo.Courses");
            DropTable("dbo.CoursesFields");
            DropTable("dbo.Teachers");
            DropTable("dbo.Answers");
            DropTable("dbo.Accounts");
        }
    }
}
