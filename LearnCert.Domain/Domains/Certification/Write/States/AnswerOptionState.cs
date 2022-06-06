using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Infrastructure;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class AnswerOptionState : BaseState
{
    public AnswerOptionState()
    {
    }
    
    public AnswerOptionState(AnswerOptionValueObject answerOption, QuestionState question)
    {
        Id = answerOption.Id;
        Description = answerOption.Description;
        IsCorrect = answerOption.IsCorrect;
        Code = answerOption.Code;
        Question = question;
    }

    public virtual Guid Id { get; set; }
    public virtual string Description { get; set; }
    public virtual int Code { get; set; }
    public virtual bool IsCorrect { get; set; }
    public virtual QuestionState Question { get; set; }
}