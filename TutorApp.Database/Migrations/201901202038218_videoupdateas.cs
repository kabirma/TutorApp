namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class videoupdateas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Videos", "Likes", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Videos", "Likes", c => c.Int(nullable: false));
        }
    }
}
