using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Domains.Certification.Write.States;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Read.Maps;

public class QuestionDescriptionModelMap : ClassMap<QuestionDescriptionModel>
{
    public QuestionDescriptionModelMap()
    {
        Table("QuestionDescriptionView");
        ReadOnly();
 
        Id(x => x.Id);
        Map(x => x.Code);
        Map(x => x.Description);
        Map(x => x.LanguageType).AsEnumString<LanguageType>();
        Map(x => x.CertificationId);
        Map(x => x.ModuleTitle);
        Map(x => x.QuestionId);

        HasMany(x => x.AnswerOptions)
            .KeyColumn("QuestionDescriptionId");
    }
}