using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.States;

namespace LearnCert.Domain.Domains.Certification.Write.Maps;

public class AnswerOptionStateMap : ClassMap<AnswerOptionState>
{
    public AnswerOptionStateMap()
    {
        Table("AnswerOption");
            
        Id(x => x.Id).GeneratedBy.Assigned();
        Map(x => x.Description);
        Map(x => x.Code);
        Map(x => x.IsCorrect);
        
        References(x => x.QuestionDescription, "QuestionDescriptionId");

    }
}