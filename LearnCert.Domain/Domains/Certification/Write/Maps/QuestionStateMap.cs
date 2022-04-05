using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.States;

namespace LearnCert.Domain.Domains.Certification.Write.Maps;

public class QuestionStateMap : ClassMap<QuestionState>
{
    public QuestionStateMap()
    {
        Table("Question");
            
        Id(x => x.Id).GeneratedBy.Assigned();
        Map(x => x.Code);

        HasMany(x => x.QuestionDescriptions)
            .KeyColumn("QuestionId")
            .Cascade.AllDeleteOrphan();

    }
}