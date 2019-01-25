namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentupdatedaas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "ZipCode", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "ZipCode");
        }
    }
}
