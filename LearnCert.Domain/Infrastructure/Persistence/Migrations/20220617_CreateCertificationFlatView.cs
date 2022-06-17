using FluentMigrator;
namespace LearnCert.Domain.Infraestructure.Persistence.Migrations;

[Migration(20220617)]
public class CreateCertificationFlatView : Migration
{
    public override void Up()
    {
        Execute.Script("../LearnCert.Domain/Infrastructure/Persistence/Migrations/Scripts/20220617_CreateCertificationFlatView.sql");
    }

    public override void Down()
    {   
        Delete.Table("CreateCertificationFlatView");
    }
}