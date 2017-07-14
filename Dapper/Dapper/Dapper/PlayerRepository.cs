using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Transactions;

namespace Contacs.Dapper
{
    public class PlayerRepository : IPlayerRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Dapper"].ConnectionString);
       public  Team Add(Team team)
        {
            var sql =
                "INSERT INTO Team (TeamName, Town) values(@TeamName, @Town); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = this.db.Query<int>(sql, team).Single();
            team.Id = id;
            return team;
        }

        public Player Find(int id) => this.db.Query<Player>("SELECT * FROM Player WHERE Id=@Id", new { id }).FirstOrDefault();

        public List<Team> GetAll()
        {
            return this.db.Query<Team>("SELECT * FROM Team").ToList();
        }

        public Player GetFullPlayer(int id)
        {
            var sql =
                "Select * From Player WHERE Id=@Id;" +
                "Select * From Player WHERE TeamId=@Id ";

            using (var multipleResults = this.db.QueryMultiple(sql, new { id }))
            {
                var player = multipleResults.Read<Player>().SingleOrDefault();
                var teams = multipleResults.Read<Team>().ToList();
                if (player != null && teams != null)
                {
                    teams.AddRange(teams);
                }

                return player;
            }
        }

        public void Remove(int id)
        {
            this.db.Execute("DELETE * FROM Team WHERE Id=@Id", new { id });
        }

        public void Save(Player player)
        {
            using (var txScope = new TransactionScope())
            {
                //if (player.IsNew)
                //{
                //    this.Add(player);
                //}
                //else
                //{
                //    this.Update(player);
                //}
                var parameters = new DynamicParameters();
                parameters.Add("@Id", value: player.Id, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@FirstName", player.FirstName);
                parameters.Add("@LastName", player.LastName);
                parameters.Add("@Age", player.Age);
                this.db.Execute("SavePlayer", parameters, commandType: CommandType.StoredProcedure);
                player.Id = parameters.Get<int>("@Id");
                //foreach (var tms in player.TeamId.Where())
                //{
                //    tms. = player.Id;

                //    //if (tms.IsNew)
                //    //{
                //    //    this.Add(tms);

                //    //}
                //    //else
                //    //{
                //    //    this.Update(tms);
                //    //}

                //    var TmsParams = new DynamicParameters(new
                //    {
                //        teamname = tms.TeamName,
                //        PlayerId = tms.,
                //        town = tms.Town,

                //    });
                //    TmsParams.Add("@Id", tms.id, DbType.Int32, ParameterDirection.InputOutput);
                //    this.db.Execute("SaveTeam", TmsParams, commandType: CommandType.StoredProcedure);
                //    tms.Pk_Team_Id = TmsParams.Get<int>("@Id");
                //}
                //foreach (var tms in player.TeamId.Where(t => t.IsDeleted))
                //{
                //    //this.db.Execute("DELETE FROM Team WHERE Pk_Team_Id = @Id", new { tms.Pk_Team_Id });
                //    this.db.Execute("DeleteTeam", new { Id = tms }, commandType: CommandType.StoredProcedure);
                //}
                //txScope.Complete();
            }
        }

        private void Add(Player player)
        {
            var sql =
                "INSERT INTO Player (First Name, LastName, Age) values(@FirstName, @LastName, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = this.db.Query<int>(sql, player).Single();
            player.Id = id;
            
        }

        public Team Update(Team team)
        {
            this.db.Execute("UPDATE Teaam SET TeamName=@TeamName,Town=@Town, WHERE Id = @Id", team);
            return team;

        }

        Player IPlayerRepository.Add(Player player)
        {
            var sql =
                "INSERT INTO Player (FirstName, LastName, Age, TeamId, Id) values(@FirstName, @LastName, @Age, @TeamId, @Id); SELECT CAST(SCOPE_IDENTITY() as int)";
             var id = this.db.Query<int>(sql, player).Single();
            player.Id = id;
            return player;
        }

        public Player Update(Player player)
        {
            this.db.Execute("UPDATE Player SET FirstName=@FirstName, LastName=@LastName, Age=@Age WHERE Id = @Id",
                player);
                            //"SET FirstName =@FirstName" +
                            //"LastName =@LastName" +
                            //"Age =@Age" +
                            //"WHERE Id = @Id", player);
            return player;
        }

        public void Update(string player)
        {
            throw new NotImplementedException();
        }

       

        public List<Player> GetFullPlayer()
        {
            //var sql =
            //    "Select * From Player WHERE Id=@Id;" +
            //    "Select * From Player WHERE TeamId=@Id ";

            //using (var multipleResults = this.db.QueryMultiple(sql, new {sql}))
            //{
            //    var player = multipleResults.Read<Player>().SingleOrDefault();
            //    var teams = multipleResults.Read<Team>().ToList();
            //    if (player != null && teams != null)
            //    {
            //        teams.AddRange(teams);
            //    }
       
                return this.db.Query<Player>("Select * From Player WHERE Id=@Id").ToList();
            //}
        }

        public Player GetfullPlayer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
