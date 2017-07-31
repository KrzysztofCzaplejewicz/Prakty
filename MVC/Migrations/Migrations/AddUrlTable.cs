using FluentMigrator;

namespace Migrations.Migrations
{
    [Migration(20170731112000)]
    public class M20170731112000AddUrlTable : Migration
    {
        public override void Up()
        {
            Create.Column("UrlIcon").OnTable("Teams").AsString().Nullable();

          }

        public override void Down()
        {
            Delete.Column("UrlIcon").FromTable("Teams");
        }
    }
}
