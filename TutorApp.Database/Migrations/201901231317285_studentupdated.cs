namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Gender", c => c.String(unicode: false));
            AddColumn("dbo.Students", "DOB", c => c.String(unicode: false));
            AddColumn("dbo.Students", "PhoneNumber", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "PhoneNumber");
            DropColumn("dbo.Students", "DOB");
            DropColumn("dbo.Students", "Gender");
        }
    }
}
