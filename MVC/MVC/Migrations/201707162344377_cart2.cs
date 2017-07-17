namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "Count");
        }
    }
}
