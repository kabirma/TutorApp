namespace TutorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentupdatedas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Lname", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Lname");
        }
    }
}
