namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leagues", "LeaugeName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leagues", "LeaugeName", c => c.String(nullable: false));
        }
    }
}
