namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentupdatedaasas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "City", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "City");
        }
    }
}
