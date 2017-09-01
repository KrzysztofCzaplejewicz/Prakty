using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Leagues (LeagueName) VALUES ('TOPLIGA')");
            migrationBuilder.Sql("INSERT INTO Leagues (LeagueName) VALUES ('PLFA 1')");
            migrationBuilder.Sql("INSERT INTO Leagues (LeagueName) VALUES ('PLFA 2')");
            migrationBuilder.Sql("INSERT INTO Leagues (LeagueName) VALUES ('PLFA 8')");

            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Primacol Lowlanders', 'Białystok', (SELECT ID FROM Leagues WHERE LeagueName = 'TOPLIGA'))");
            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Panters', 'Wrocław', (SELECT ID FROM Leagues WHERE LeagueName = 'TOPLIGA'))");
            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Seahawks', 'Gdynia', (SELECT ID FROM Leagues WHERE LeagueName = 'TOPLIGA'))");
            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Falcons', 'Tychy', (SELECT ID FROM Leagues WHERE LeagueName = 'TOPLIGA'))");
            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Eagels', 'Warsaw', (SELECT ID FROM Leagues WHERE LeagueName = 'TOPLIGA'))");

            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Kings', 'Kraków', (SELECT ID FROM Leagues WHERE LeagueName = 'PLFA 1'))");
            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Dukes', 'Warsaw', (SELECT ID FROM Leagues WHERE LeagueName = 'PLFA 1'))");
            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Sharks', 'Warsaw', (SELECT ID FROM Leagues WHERE LeagueName = 'PLFA 1'))");

            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Patrioci', 'Poznań', (SELECT ID FROM Leagues WHERE LeagueName = 'PLFA 2'))");
            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Mustangs', 'Płock', (SELECT ID FROM Leagues WHERE LeagueName = 'PLFA 2'))");
            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Owls', 'Bielawa', (SELECT ID FROM Leagues WHERE LeagueName = 'PLFA 2'))");
            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Tytani', 'Lublin', (SELECT ID FROM Leagues WHERE LeagueName = 'PLFA 2'))");

            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('LowlandersB', 'Białystok', (SELECT ID FROM Leagues WHERE LeagueName = 'PLFA 8'))");
            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('EagelsB', 'Warsaw', (SELECT ID FROM Leagues WHERE LeagueName = 'PLFA 8'))");
            migrationBuilder.Sql("INSERT INTO Teams (TeamName, Town, LeagueId) VALUES ('Cougars', 'Szczecin', (SELECT ID FROM Leagues WHERE LeagueName = 'PLFA 8'))");

            migrationBuilder.Sql("INSERT INTO Players (Name, LastName, Age, TeamId) VALUES ('Krzysztof', 'Czaplejewicz', '24', (SELECT ID FROM Teams WHERE TeamName = 'Primacol Lowlanders'))");
            migrationBuilder.Sql("INSERT INTO Players (Name, LastName, Age, TeamId) VALUES ('Paweł', 'Czaplejewicz', '24', (SELECT ID FROM Teams WHERE TeamName = 'Primacol Lowlanders'))");
            migrationBuilder.Sql("INSERT INTO Players (Name, LastName, Age, TeamId) VALUES ('Paweł', 'Kondzior', '24', (SELECT ID FROM Teams WHERE TeamName = 'Primacol Lowlanders'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Players");
            migrationBuilder.Sql("DELETE FROM Teams");
            migrationBuilder.Sql("DELETE FROM Leagues");
        }
    }
}
