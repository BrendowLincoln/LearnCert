using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Infrastructure;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class QuestionState : BaseState
{
    public QuestionState()
    {
    }

    public QuestionState(QuestionValueObject question)
    {
        Id = question.Id;
        Code = question.Code;
        QuestionDescriptions = question.QuestionDescriptions.Select(x => new QuestionDescriptionState(x)).ToList();
    }

    public virtual Guid Id { get; set; }
    public virtual int Code { get; set; }
    
    public virtual IList<QuestionDescriptionState> QuestionDescriptions { get; set; }
}