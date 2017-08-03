//using FluentMigrator;

//namespace Migrations.Migrations
//{
//    [Migration(20170725101500)]
//    public class M20170721195000UpdateGameTable : Migration
//    {


//        public override void Up()
//        {
//            Create.Column("Host").OnTable("Games").AsString().NotNullable();
//            Create.Column("Visitor").OnTable("Games").AsString().NotNullable();
//        }
//        public override void Down()
//        {
//            Delete.Column("Host").FromTable("Games");
//            Delete.Column("Visitor").FromTable("Games");
//        }
//    }
//}
