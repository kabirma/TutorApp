namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class videoupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Likes", c => c.Int(nullable: false));
            AddColumn("dbo.Videos", "ImageUrl", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "ImageUrl");
            DropColumn("dbo.Videos", "Likes");
        }
    }
}
