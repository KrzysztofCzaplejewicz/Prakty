//using System;
//using System.CodeDom;
//using System.Collections.Generic;
//using System.Linq;
//using Dapper;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;

//namespace DapperInsert
//{
//    public class ContactsRepository : IContactsRepository
//    {
//        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Dapper"].ConnectionString);

//        public IDbConnection Db
//        {
//            get => db;
//            set => db = value;
//        }

//        bool IContactsRepository.Update(Player player, string columnWidth, Team team, string columName)
//        {
//            string query =
//                "Update Player set  FirstName=@Firstname , LastName=@LastName, Age=@Age   Where Id=@Pk_Player_Id";
//            var count = Db.Execute(query, player);
//            return count > 0;
//        }

//        bool IContactsRepository.Delate(int id)
//        {
//            var affectedrows = Db.Execute("Delete from Player where Pk_Player_Id=@Pk_Player_Id", new {Id = id});
//            return affectedrows > 0;
//        }

//        public Player GetById(int id)
//        {
//            return Db.Query<Player>("Select * From Player Where Id=@Pk_Player_Id", new {Id = id}).FirstOrDefault();
//        }

//        public List<Team> GetAll()
//        {
//            return Db.Query<Team>("Select * From Team").ToList();

//        }

//        bool IContactsRepository.Add(Player player, Team teams)
//        {
//            try
//            {
//                string sql =
//                    "INSERT INTO Player, Teams(FirstName,LastName,Age, TeamName, Town) values(@FirstName,@LastName,@Age,@TeamName,@Town); SELECT CAST(SCOPE_IDENTITY() as int)";
//                var returnId = Db.Query<int>(sql, player).SingleOrDefault();
//                player.Pk_Player_Id = returnId;
//            }
//            catch (Exception ex)
//            {

//                return false;
//            }
//            return true;
//        }

//        public bool Update(Player person, String columnName)
//        {
//            string query = "update Player set " + columnName + "=@FirstName" + columnName + " Where Id=@Pk_Player_Id";
//            var count = Db.Execute(query, person);
//            return count > 0;
//        }

//        List<Dapper.Player> IContactsRepository.GetAll()
//        {
//            return Db.Query<Player>("Select * From Player").ToList();
//        }

//        Player IContactsRepository.GetById(int id)
//        {
//            return Db.Query<Player>("Select * From Player Where Id=@Pk_Player_Id", new {Id = id}).FirstOrDefault();
//        }

//        bool IContactsRepository.Update(Dapper.Player player, Team team, string columnWidth)
//        {
//            throw new NotImplementedException();
//        }

//        void IContactsRepository.Update(Dapper.Player person, string name)
//        {
//            throw new NotImplementedException();
//        }

//        void IContactsRepository.Add(Player player)
//        {
//            string sql =
//                "INSERT INTO Player, Teams(FirstName,LastName,Age, TeamName, Town) values(@FirstName,@LastName,@Age,@TeamName,@Town); SELECT CAST(SCOPE_IDENTITY() as int)";
//            var returnId = Db.Query<int>(sql, player).SingleOrDefault();
//            player.Pk_Player_Id = returnId;
//        }

//        public bool Add(Player player, Team team)
//        {
//            throw new NotImplementedException();
//        }

//        void IContactsRepository.Add(Team team)
//        {
//            try
//            {
//                string sql =
//                    "INSERT INTO Team, Teams(TeamName,Town) values(@TeamName,@Town); SELECT CAST(SCOPE_IDENTITY() as int)";
//                var returnId = Db.Query<int>(sql, team).SingleOrDefault();
//                team.Pk_Team_Id = returnId;

//            }
//            finally
//            {
                
//            }









//        }

//        //    public bool Update(Player player, Team team, string columnWidth)
//        //    {
//        //        throw new


//        //    public bool Update(Player player, string columnWidth, Team team, string columnName)
//        //        {
//        //            throw new NotImplementedException();
//        //        }
//        //    }
//    }
//}