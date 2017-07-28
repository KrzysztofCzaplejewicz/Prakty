using FluentMigrator;

namespace Migrations.Migrations
{
    [Migration(20170726093100)]
    public class M20170726093100ChangeGamesTable : Migration
    {
        public override void Up()
        {
            //Delete.ForeignKey("FK_Games_Leagues").OnTable("Games");
            Delete.ForeignKey("FK_Games_Teams").OnTable("Games");
            Delete.Column("TeamId").FromTable("Games");
            //Delete.Column("League").FromTable("Games");

            //Create.Column("Host").OnTable("Games").AsString().NotNullable();
           // Create.Column("Visitor").OnTable("Games").AsString().NotNullable();

            Create.ForeignKey("FK_Games_Teams")
                .FromTable("Games").ForeignColumns("Host", "Visitor")
                .ToTable("Teams").PrimaryColumns("Id" , "Id");


        }

        public override void Down()
        {
            
           Delete.ForeignKey("FK_Games_Table");


        }
    }
}
