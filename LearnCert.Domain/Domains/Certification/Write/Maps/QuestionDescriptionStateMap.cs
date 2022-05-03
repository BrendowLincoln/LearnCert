using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Domains.Certification.Write.States;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Write.Maps;

public class QuestionDescriptionStateMap : ClassMap<QuestionDescriptionState>
{
    public QuestionDescriptionStateMap()
    {
        Table("QuestionDescription");
            
        Id(x => x.Id).GeneratedBy.Assigned();
        Map(x => x.Description);
        Map(x => x.LanguageType).AsEnumString<LanguageType>();

        References(x => x.Question, "QuestionId");
        
        HasMany(x => x.AnswerOptions)
            .KeyColumn("QuestionDescriptionId")
            .Cascade.AllDeleteOrphan();

    }
}