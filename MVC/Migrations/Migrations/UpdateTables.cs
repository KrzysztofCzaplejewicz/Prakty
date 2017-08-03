//using FluentMigrator;

//namespace Migrations.Migrations
//{
//    [Migration(20170721195000)]
//    public class M20170721195000UpdateTables : Migration
//    {
//        public override void Down()
//        {
//            Create.Column("Team_Id").OnTable("Players").AsInt32();
//            Create.Column("LeagueId").OnTable("Players").AsInt32();
//            Create.ForeignKey("FK_dbo.Players_dbo.Leagues_LeagueId").FromTable("Players");
//            Delete.Column("LeagueId").FromTable("Teams");
//            Delete.ForeignKey("FK_dbo.Teams_dbo.Leagues_LeagueId");
//            //Create.ForeignKey("IX_Team_Id").FromTable("Players").ForeignColumn("Team_Id").ToTable("Teams")
//            //    .PrimaryColumn("Id");
//            Create.Index("IX_Team_Id").OnTable("Players");
//            Create.Index("LeagueId").OnTable("Players");
//        }

//        public override void Up()
//        {
//            Delete.Index("IX_LeagueId").OnTable("Players");
//            Delete.Index("IX_Team_Id").OnTable("Players");
//            Delete.ForeignKey("FK_dbo.Players_dbo.Leagues_LeagueId").OnTable("Players");
//            Delete.Column("Team_Id").FromTable("Players");
//            Delete.Column("LeagueId").FromTable("Players");



//            Create.Column("LeagueId").OnTable("Teams").AsInt32().Nullable();
//            Create.ForeignKey("FK_dbo.Teams_dbo.Leagues_LeagueId").FromTable("Teams").ForeignColumn("LeagueId").ToTable("Leagues").PrimaryColumn("Id");
//        }
//    }
//}
