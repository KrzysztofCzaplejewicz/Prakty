namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart21 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Teams", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "Count", c => c.Int(nullable: false));
        }
    }
}
