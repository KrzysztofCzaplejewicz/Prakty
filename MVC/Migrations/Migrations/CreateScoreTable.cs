using FluentMigrator;
using System;

namespace Migrations.Migrations
{
    [Migration(20170804111500)]
    public class CreateScoreTable : Migration
    {
        public override void Up()
        {
            Create.Table("Scores")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("GameId").AsInt32().NotNullable().ForeignKey()
                .WithColumn("ScoreHost").AsInt32()
                .WithColumn("ScoreVisitor").AsInt32()
                ;

            
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
