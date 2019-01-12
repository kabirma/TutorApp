namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursesup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyDetails", "Description", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyDetails", "Description");
        }
    }
}
