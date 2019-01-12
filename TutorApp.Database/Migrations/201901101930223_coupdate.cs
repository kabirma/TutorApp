namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyDetails", "AboutImage", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyDetails", "AboutImage");
        }
    }
}
