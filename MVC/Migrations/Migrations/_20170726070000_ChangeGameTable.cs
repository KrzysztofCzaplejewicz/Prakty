//using FluentMigrator;

//namespace Migrations.Migrations
//{
//    [Migration(20170726070000)]
//    public class M20170726070000ChangeGameTable : Migration
//    {


//        public override void Up()
//        {
//            Create.Column("TeamVisitorId").OnTable("Games").AsInt32().NotNullable();
//            Create.ForeignKey("FK_dbo.Games_dbo.Teams_TeamVisitorId").FromTable("Games").ForeignColumn("TeamVisitorId")
//                .ToTable("Teams").PrimaryColumn("Id");


//        }

//        public override void Down()
//        {
//            Delete.ForeignKey("FK_dbo.Games_dbo.Teams_TeamVisitorId").OnTable("Games");
//            Delete.Column("TeamVisitorId").FromTable("Games");

//        }
//    }
//}

