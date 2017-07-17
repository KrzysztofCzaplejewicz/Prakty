namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaugeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        LeagueId = c.Int(nullable: false),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leagues", t => t.LeagueId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId)
                .Index(t => t.LeagueId)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        Town = c.String(),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.Player_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Players", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Players", "LeagueId", "dbo.Leagues");
            DropIndex("dbo.Teams", new[] { "Player_Id" });
            DropIndex("dbo.Players", new[] { "Team_Id" });
            DropIndex("dbo.Players", new[] { "LeagueId" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropTable("dbo.Teams");
            DropTable("dbo.Players");
            DropTable("dbo.Leagues");
        }
    }
}
