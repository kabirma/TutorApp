namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inboxes", "Date", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inboxes", "Date");
        }
    }
}
