using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Infrastructure;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class QuestionState : BaseState
{
    public QuestionState()
    {
    }

    public QuestionState(QuestionValueObject question, ModuleState module)
    {
        Id = question.Id;
        Code = question.Code;
        Description = question.Description;
        Module = module;
        AnswerOptions = question.AnswerOptions.Select(x => new AnswerOptionState(x, this)).ToList();

    }

    public virtual Guid Id { get; set; }
    public virtual int Code { get; set; }
    public virtual string Description { get; set; }
    public virtual IList<AnswerOptionState> AnswerOptions { get; set; }
    public virtual ModuleState Module { get; set; }
}