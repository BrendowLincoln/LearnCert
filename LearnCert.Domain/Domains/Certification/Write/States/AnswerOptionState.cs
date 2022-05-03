using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Infrastructure;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class AnswerOptionState : BaseState
{
    public AnswerOptionState()
    {
    }
    
    public AnswerOptionState(AnswerOptionValueObject answerOption, QuestionDescriptionState questionDescription)
    {
        Id = answerOption.Id;
        Description = answerOption.Description;
        IsCorrect = answerOption.IsCorrect;
        QuestionDescription = questionDescription;
        Code = answerOption.Code;
    }

    public virtual Guid Id { get; set; }
    public virtual string Description { get; set; }
    public virtual int Code { get; set; }
    public virtual bool IsCorrect { get; set; }
    public virtual QuestionDescriptionState QuestionDescription { get; set; }
}