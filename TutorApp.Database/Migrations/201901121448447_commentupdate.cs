namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VideoComments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Comment = c.String(unicode: false),
                        Date = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Video_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Videos", t => t.Video_ID)
                .Index(t => t.Video_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoComments", "Video_ID", "dbo.Videos");
            DropIndex("dbo.VideoComments", new[] { "Video_ID" });
            DropTable("dbo.VideoComments");
        }
    }
}
