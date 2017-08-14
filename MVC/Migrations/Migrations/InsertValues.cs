//using FluentMigrator;

//namespace Migrations.Migrations
//{
//    [Migration(20170802070500)]
//    public class InsertValues : Migration
//    {
//        public override void Up()
//        {

//            Insert.IntoTable("Players")
//                .Row(new { FirstName = "Albert", LastName = "Smith", Age = "24" })
//                .Row(new { FirstName = "Krzysztof", LastName = "Kononowicz", Age = "24" })

//                ;

//            Insert.IntoTable("Teams")
//                .Row(new { TeamName = "Eagels", Town = "Warszawa", UrlIcon = "" })

//                ;

//            Insert.IntoTable("Seasons")
//                .Row(new { Season = "2018" })

//                ;
//        }

//        public override void Down()
//        {
//            Delete.Table("Players");
//            Delete.Table("Teams");
//            Delete.Table("Seasons");
//            Delete.Table("PlayerTeam");
//        }
//    }
//}
