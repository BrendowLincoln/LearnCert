using FluentMigrator;

namespace LearnCert.Domain.Infraestructure.Persistence.Migrations;

[Migration(20220313)]
public class CreateBookTable : Migration
{
    public override void Up()
    {
        Create.Table("Book")
            .WithColumn("Id").AsUUID().PrimaryKey()
            .WithColumn("Title").AsString();
    }

    public override void Down()
    {
        Delete.Table("Book");
    }
}