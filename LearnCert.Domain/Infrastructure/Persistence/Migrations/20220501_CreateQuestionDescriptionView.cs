using FluentMigrator;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Infraestructure.Persistence.Migrations;

[Migration(20220501)]
public class CreateQuestionDescriptionView  : Migration
{
    public override void Up()
    {
        Execute.Script("../LearnCert.Domain/Infrastructure/Persistence/Migrations/Scripts/20220501_CreateQuestionDescriptionView.sql");
    }

    public override void Down()
    {   
    }
}