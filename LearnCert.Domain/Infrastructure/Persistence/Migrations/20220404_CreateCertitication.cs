using FluentMigrator;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Infraestructure.Persistence.Migrations;

[Migration(20220404)]
public class CreateCertitication  : Migration
{
    public override void Up()
    {
        Create.Table("AnswerOption")
            .WithColumn("Id").AsUUID().NotNullable()
            .WithColumn("Code").AsInt32().NotNullable()
            .WithColumn("Description").AsString().NotNullable()
            .WithColumn("IsCorrect").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("QuestionId").AsUUID().NotNullable();
        
        Create.Table("Question")
            .WithColumn("Id").AsUUID().PrimaryKey()
            .WithColumn("Code").AsInt32().NotNullable()
            .WithColumn("Description").AsString().NotNullable()
            .WithColumn("ModuleId").AsUUID().NotNullable();
        
        Create.ForeignKey("FK_AnswerOption_Question")
            .FromTable("AnswerOption").ForeignColumn("QuestionId")
            .ToTable("Question").PrimaryColumn("Id");
        
        Create.Table("Module")
            .WithColumn("Id").AsUUID().PrimaryKey()
            .WithColumn("Title").AsString().NotNullable()
            .WithColumn("Code").AsInt32().NotNullable()
            .WithColumn("CertificationId").AsUUID().NotNullable();
        
        Create.ForeignKey("FK_Question_Module")
            .FromTable("Question").ForeignColumn("ModuleId")
            .ToTable("Module").PrimaryColumn("Id");
        
        Create.Table("Certification")
            .WithColumn("Id").AsUUID().PrimaryKey()
            .WithColumn("Title").AsString().NotNullable()
            .WithColumn("LanguageType").AsString(50).NotNullable();
        
        Create.ForeignKey("FK_Module_Certification")
            .FromTable("Module").ForeignColumn("CertificationId")
            .ToTable("Certification").PrimaryColumn("Id");

    }

    public override void Down()
    {
        Delete.ForeignKey("FK_AnswerOption_Question");
        Delete.ForeignKey("FK_Question_Module");
        Delete.ForeignKey("FK_Module_Certification");
        Delete.Table("AnswerOption");
        Delete.Table("Question");
        Delete.Table("Module");
        Delete.Table("Certification");
    }
}