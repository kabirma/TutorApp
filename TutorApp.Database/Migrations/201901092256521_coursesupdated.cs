namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursesupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Rating", c => c.String(unicode: false));
            AddColumn("dbo.Courses", "IsFeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "IsFeatured");
            DropColumn("dbo.Teachers", "Rating");
        }
    }
}
