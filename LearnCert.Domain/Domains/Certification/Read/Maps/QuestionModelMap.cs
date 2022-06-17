using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.States;

namespace LearnCert.Domain.Domains.Certification.Read.Maps;

public class QuestionModelMap : ClassMap<QuestionModel>
{
    public QuestionModelMap()
    {
        Table("Question");
        ReadOnly();
 
        Id(x => x.Id);
        Map(x => x.Code);
        Map(x => x.Description);
        Map(x => x.ModuleId);

        HasMany(x => x.AnswerOptions)
            .KeyColumn("QuestionId");
    }
}