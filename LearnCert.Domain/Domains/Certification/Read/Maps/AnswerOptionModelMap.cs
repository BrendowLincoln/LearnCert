using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.States;

namespace LearnCert.Domain.Domains.Certification.Read.Maps;

public class AnswerOptionModelMap : ClassMap<AnswerOptionModel>
{
    public AnswerOptionModelMap()
    {
        Table("AnswerOption");
        ReadOnly();
 
        Id(x => x.Id);
        Map(x => x.Code);
        Map(x => x.Description);
        Map(x => x.IsCorrect);
    }
}