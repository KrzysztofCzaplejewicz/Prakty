using FluentMigrator;

namespace Migrations.Migrations
{
    [Migration(20170801150000)]
    public class CreateNewTables : Migration
    {
        public override void Up()
        {
            Create.Table("Players")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(255).NotNullable()
                .WithColumn("LastName").AsString(255).NotNullable()
                .WithColumn("Age").AsInt32().NotNullable();

            Create.Table("Teams")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("TeamName").AsString(255).NotNullable()
                .WithColumn("Town").AsString(255).NotNullable()
                .WithColumn("UrlIcon").AsString(255).Nullable()
                ;

            Create.Table("Seasons")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Season").AsInt32().NotNullable();

            Create.Table("PlayerTeam")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("PlayerId").AsInt32().ForeignKey()
                .WithColumn("TeamId").AsInt32().ForeignKey()
                .WithColumn("SeasonId").AsInt32().ForeignKey();

            Create.ForeignKey()
                .FromTable("PlayerTeam").ForeignColumn("PlayerId")
                .ToTable("Players").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable("PlayerTeam").ForeignColumn("TeamId")
                .ToTable("Teams").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable("PlayerTeam").ForeignColumn("SeasonId")
                .ToTable("Seasons").PrimaryColumn("Id");

            Insert.IntoTable("Players")
                .Row(new { FirstName = "John", LastName = "Smith", Age="24" })
                .Row(new { FirstName = "Krzysztof", LastName = "Czaplejewicz", Age="24" })
                .Row(new { FirstName = "Paweł", LastName = "Czaplejewicz", Age="26" })
                .Row(new { FirstName = "Paweł", LastName = "Kondzior", Age="28" })
                .Row(new { FirstName = "Tomasz", LastName = "Muśko", Age="19" })
                .Row(new { FirstName = "Kacper", LastName = "Łupiński", Age="19" })
                .Row(new { FirstName = "Stefan", LastName = "Łupiński", Age="21" })
                .Row(new { FirstName = "Stefan", LastName = "Maksimowicz", Age="21" })
                .Row(new { FirstName = "Michał", LastName = "Maksimowicz", Age="31" })
                .Row(new { FirstName = "Wojtek", LastName = "Maksimowicz", Age="23" })
                .Row(new { FirstName = "Piotr", LastName =  "Maksimowicz", Age="24" })
                .Row(new { FirstName = "Andrzej", LastName = "Maksimowicz", Age="25" })
                .Row(new { FirstName = "Maciej", LastName = "Maksimowicz", Age="25" })
                .Row(new { FirstName = "Adam", LastName = "Maksimowicz", Age="21" })
                .Row(new { FirstName = "Michał", LastName = "Nowak", Age="31" })
                .Row(new { FirstName = "Wojtek", LastName = "Nowak", Age="21" })
                .Row(new { FirstName = "Piotr", LastName =  "Nowak", Age="18" })
                .Row(new { FirstName = "Andrzej", LastName = "Nowak", Age="25" })
                .Row(new { FirstName = "Maciej", LastName = "Nowak", Age="25" })
                .Row(new { FirstName = "Michał", LastName = "Kowalski", Age="33" })
                .Row(new { FirstName = "Wojtek", LastName = "Kowalski", Age="44" })
                .Row(new { FirstName = "Piotr", LastName =  "Kowalski", Age="22" })
                .Row(new { FirstName = "Maciej", LastName = "Kowalski", Age="26" })
                .Row(new { FirstName = "Robert", LastName = "Kowalski", Age="55" })
                .Row(new { FirstName = "Bartosz", LastName = "Trubaj", Age="26" })
                ;

            Insert.IntoTable("Teams")
                .Row(new{ TeamName = "Lowlanders", Town = "Białystok", UrlIcon = ""})
                .Row(new{ TeamName = "LowlandersB", Town = "Białystok", UrlIcon = "" })
                .Row(new{ TeamName = "Panters", Town = "Wrocław", UrlIcon = "" })
                .Row(new{ TeamName = "PantersB", Town = "Wrocław", UrlIcon = "" })
                .Row(new{ TeamName = "Outlaws", Town = "Wrocław", UrlIcon = "" })
                .Row(new{ TeamName = "Seahawks", Town = "Gdynia", UrlIcon = "" })
                .Row(new{ TeamName = "SeahawksB", Town = "Gdynia", UrlIcon = "" })
                .Row(new{ TeamName = "Seahawks", Town = "Sopot", UrlIcon = "" })
                .Row(new{ TeamName = "Falcons", Town = "Tychy", UrlIcon = "" })
                .Row(new{ TeamName = "Tytani", Town = "Lublin", UrlIcon = "" })
                .Row(new{ TeamName = "Rhinos", Town = "Wyszków", UrlIcon = "" })
                ;

            Insert.IntoTable("Seasons")
                .Row(new{ Season = "2017" })
                .Row(new{ Season = "2016" })
                .Row(new{ Season = "2015" })
                .Row(new{ Season = "2014" })
                ;
        }

        public override void Down()
        {
            Delete.Table("Players");
            Delete.Table("Teams");
            Delete.Table("Seasons");
            Delete.Table("PlayerTeam");
        }
    }
}
