using FluentMigrator;

namespace LearnCert.Domain.Infraestructure.Persistence.Migrations.Scripts;

[Migration(20220617_2)]
public class AddImageUrlColumnCertification : Migration
{
    public override void Up()
    {
        Alter.Table("Certification").AddColumn("ImageUrl").AsString();
    }

    public override void Down()
    {
        Delete.Column("ImageUrl").FromTable("Certification");
    }
}