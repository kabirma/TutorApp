namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatehappend : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Accounts", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Category", c => c.String(unicode: false));
        }
    }
}
