namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacherupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "TeachingSubjects2_ID", c => c.Int());
            AddColumn("dbo.Teachers", "TeachingSubjects3_ID", c => c.Int());
            AddColumn("dbo.Teachers", "TeachingSubjects4_ID", c => c.Int());
            AddColumn("dbo.Teachers", "TeachingSubjects5_ID", c => c.Int());
            CreateIndex("dbo.Teachers", "TeachingSubjects2_ID");
            CreateIndex("dbo.Teachers", "TeachingSubjects3_ID");
            CreateIndex("dbo.Teachers", "TeachingSubjects4_ID");
            CreateIndex("dbo.Teachers", "TeachingSubjects5_ID");
            AddForeignKey("dbo.Teachers", "TeachingSubjects2_ID", "dbo.CoursesFields", "ID");
            AddForeignKey("dbo.Teachers", "TeachingSubjects3_ID", "dbo.CoursesFields", "ID");
            AddForeignKey("dbo.Teachers", "TeachingSubjects4_ID", "dbo.CoursesFields", "ID");
            AddForeignKey("dbo.Teachers", "TeachingSubjects5_ID", "dbo.CoursesFields", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "TeachingSubjects5_ID", "dbo.CoursesFields");
            DropForeignKey("dbo.Teachers", "TeachingSubjects4_ID", "dbo.CoursesFields");
            DropForeignKey("dbo.Teachers", "TeachingSubjects3_ID", "dbo.CoursesFields");
            DropForeignKey("dbo.Teachers", "TeachingSubjects2_ID", "dbo.CoursesFields");
            DropIndex("dbo.Teachers", new[] { "TeachingSubjects5_ID" });
            DropIndex("dbo.Teachers", new[] { "TeachingSubjects4_ID" });
            DropIndex("dbo.Teachers", new[] { "TeachingSubjects3_ID" });
            DropIndex("dbo.Teachers", new[] { "TeachingSubjects2_ID" });
            DropColumn("dbo.Teachers", "TeachingSubjects5_ID");
            DropColumn("dbo.Teachers", "TeachingSubjects4_ID");
            DropColumn("dbo.Teachers", "TeachingSubjects3_ID");
            DropColumn("dbo.Teachers", "TeachingSubjects2_ID");
        }
    }
}
