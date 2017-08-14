//using FluentMigrator;
//using System;

//namespace Migrations.Migrations
//{
//    [Migration(20170802093300)]
//    public class InsertValuesPlayerTeamTable : Migration
//    {
//        public override void Up()
//        {
//            Insert.IntoTable("PlayerTeam")

//                //sezon2017

//                .Row(new { PlayerId= 2, TeamId= 1 , SeasonId= 1 })
//                .Row(new { PlayerId= 3, TeamId= 1 , SeasonId= 1 })
//                .Row(new { PlayerId= 4, TeamId= 1 , SeasonId= 1 })
//                .Row(new { PlayerId= 5, TeamId= 1 , SeasonId= 1 })
//                .Row(new { PlayerId= 6, TeamId= 1 , SeasonId= 1 })
//                .Row(new { PlayerId= 7, TeamId= 1 , SeasonId= 1 })
//                .Row(new { PlayerId= 8, TeamId= 1 , SeasonId= 1 })
//                .Row(new { PlayerId= 9, TeamId= 1 , SeasonId= 1 })
//                .Row(new { PlayerId= 10, TeamId= 1 , SeasonId= 1 })
//                .Row(new { PlayerId= 11, TeamId= 1 , SeasonId= 1 })
//                .Row(new { PlayerId= 12, TeamId= 1 , SeasonId= 1 })

//                .Row(new { PlayerId = 13, TeamId = 2, SeasonId = 1 })
//                .Row(new { PlayerId = 14, TeamId = 2, SeasonId = 1 })
//                .Row(new { PlayerId = 15, TeamId = 2, SeasonId = 1 })
//                .Row(new { PlayerId = 16, TeamId = 2, SeasonId = 1 })
//                .Row(new { PlayerId = 17, TeamId = 2, SeasonId = 1 })
//                .Row(new { PlayerId = 18, TeamId = 2, SeasonId = 1 })
//                .Row(new { PlayerId = 19, TeamId = 2, SeasonId = 1 })
//                .Row(new { PlayerId = 20, TeamId = 2, SeasonId = 1 })

//                .Row(new { PlayerId = 21, TeamId = 3, SeasonId = 1 })
//                .Row(new { PlayerId = 22, TeamId = 3, SeasonId = 1 })
//                .Row(new { PlayerId = 23, TeamId = 3, SeasonId = 1 })
//                .Row(new { PlayerId = 24, TeamId = 3, SeasonId = 1 })
//                .Row(new { PlayerId = 25, TeamId = 3, SeasonId = 1 })
//                .Row(new { PlayerId = 26, TeamId = 3, SeasonId = 1 })
//                .Row(new { PlayerId = 27, TeamId = 3, SeasonId = 1 })

//                //sezon2016

//                .Row(new { PlayerId = 2, TeamId = 1, SeasonId = 2 })
//                .Row(new { PlayerId = 3, TeamId = 1, SeasonId = 2 })
//                .Row(new { PlayerId = 4, TeamId = 1, SeasonId = 2 })
//                .Row(new { PlayerId = 5, TeamId = 1, SeasonId = 2 })
//                .Row(new { PlayerId = 6, TeamId = 1, SeasonId = 2 })
//                .Row(new { PlayerId = 7, TeamId = 1, SeasonId = 2 })
//                .Row(new { PlayerId = 8, TeamId = 1, SeasonId = 2 })
//                .Row(new { PlayerId = 9, TeamId = 1, SeasonId = 2 })

//                .Row(new { PlayerId = 13, TeamId = 2, SeasonId = 2 })
//                .Row(new { PlayerId = 14, TeamId = 2, SeasonId = 2 })
//                .Row(new { PlayerId = 15, TeamId = 2, SeasonId = 2 })
//                .Row(new { PlayerId = 16, TeamId = 2, SeasonId = 2 })
//                .Row(new { PlayerId = 17, TeamId = 2, SeasonId = 2 })
//                .Row(new { PlayerId = 18, TeamId = 2, SeasonId = 2 })
//                .Row(new { PlayerId = 19, TeamId = 2, SeasonId = 2 })
//                .Row(new { PlayerId = 20, TeamId = 2, SeasonId = 2 })
//                .Row(new { PlayerId = 10, TeamId = 2, SeasonId = 2 })
//                .Row(new { PlayerId = 11, TeamId = 2, SeasonId = 2 })
//                .Row(new { PlayerId = 12, TeamId = 2, SeasonId = 2 })

//                .Row(new { PlayerId = 21, TeamId = 3, SeasonId = 2 })
//                .Row(new { PlayerId = 22, TeamId = 3, SeasonId = 2 })
//                .Row(new { PlayerId = 23, TeamId = 3, SeasonId = 2 })
//                .Row(new { PlayerId = 24, TeamId = 3, SeasonId = 2 })
//                .Row(new { PlayerId = 25, TeamId = 3, SeasonId = 2 })
//                .Row(new { PlayerId = 26, TeamId = 3, SeasonId = 2 })
//                .Row(new { PlayerId = 27, TeamId = 3, SeasonId = 2 })

//                //sezon2015

//                .Row(new { PlayerId = 13, TeamId = 2, SeasonId = 3 })
//                .Row(new { PlayerId = 14, TeamId = 2, SeasonId = 3 })
//                .Row(new { PlayerId = 15, TeamId = 2, SeasonId = 3 })
//                .Row(new { PlayerId = 16, TeamId = 2, SeasonId = 3 })
//                .Row(new { PlayerId = 17, TeamId = 2, SeasonId = 3 })
//                .Row(new { PlayerId = 18, TeamId = 2, SeasonId = 3 })
//                .Row(new { PlayerId = 19, TeamId = 2, SeasonId = 3 })
//                .Row(new { PlayerId = 20, TeamId = 2, SeasonId = 3 })
//                .Row(new { PlayerId = 10, TeamId = 2, SeasonId = 3 })
//                .Row(new { PlayerId = 11, TeamId = 2, SeasonId = 3 })
//                .Row(new { PlayerId = 12, TeamId = 2, SeasonId = 3 })

//                .Row(new { PlayerId = 21, TeamId = 3, SeasonId = 3 })
//                .Row(new { PlayerId = 22, TeamId = 3, SeasonId = 3 })
//                .Row(new { PlayerId = 23, TeamId = 3, SeasonId = 3 })
//                .Row(new { PlayerId = 24, TeamId = 3, SeasonId = 3 })
//                .Row(new { PlayerId = 25, TeamId = 3, SeasonId = 3 })
//                .Row(new { PlayerId = 26, TeamId = 3, SeasonId = 3 })
//                .Row(new { PlayerId = 27, TeamId = 3, SeasonId = 3 })


//                ;
//        }

//        public override void Down()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
