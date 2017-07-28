////using FluentMigrator;

//namespace Migrations.Migrations
//{
//    [Migration(20170719103800)]
//    public class M20170719103800CreateNewTable : Migration
//    {
//        public override void Up()
//        {
//            Create.Table("Member")
//                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
//                .WithColumn("FirstName").AsString(50)
//                .WithColumn("LastName").AsString(50)
//                .WithColumn("Age").AsInt32();

//        }

//        public override void Down()
//        {
//            Delete.Table("Member");
//        }
//    }


//}