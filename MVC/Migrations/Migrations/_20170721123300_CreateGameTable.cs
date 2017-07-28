//using FluentMigrator;

//namespace Migrations.Migrations
//{
//    [Migration(20170721123300)]
//    public class M20170721123300CreateNewTable : Migration
//    {
//        public override void Up()
//        {
//            Create.Table("Games")
//                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
//                .WithColumn("DateTime").AsString(50)
//                .WithColumn("Town").AsString(50)
//                .WithColumn("TeamId").AsInt32().NotNullable().ForeignKey()
//                .WithColumn("LeagueId").AsInt32().NotNullable().ForeignKey();



//        }

//        public override void Down()
//        {
//            Delete.Table("Games");
//        }
//    }
//}
