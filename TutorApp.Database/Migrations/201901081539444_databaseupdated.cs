namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseupdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhoneNo = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        City = c.String(unicode: false),
                        State = c.String(unicode: false),
                        Imageurl = c.String(unicode: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Inboxes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(unicode: false),
                        Subject = c.String(unicode: false),
                        Message = c.String(unicode: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Inboxes");
            DropTable("dbo.CompanyDetails");
        }
    }
}
