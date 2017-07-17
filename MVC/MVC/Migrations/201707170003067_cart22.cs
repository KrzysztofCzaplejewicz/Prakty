namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart22 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teams", "TeamName", c => c.String(nullable: false));
            AlterColumn("dbo.Teams", "Town", c => c.String(nullable: false));
            AlterColumn("dbo.Players", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Players", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Leagues", "LeaugeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leagues", "LeaugeName", c => c.String());
            AlterColumn("dbo.Players", "LastName", c => c.String());
            AlterColumn("dbo.Players", "FirstName", c => c.String());
            AlterColumn("dbo.Teams", "Town", c => c.String());
            AlterColumn("dbo.Teams", "TeamName", c => c.String());
        }
    }
}
