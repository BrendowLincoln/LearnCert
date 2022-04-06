using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Infrastructure;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class QuestionDescriptionState : BaseState
{
    public QuestionDescriptionState()
    {
    }
    
    public QuestionDescriptionState(QuestionDescriptionValueObject questionDescription, QuestionState question)
    {
        Id = questionDescription.Id;
        Description = questionDescription.Description;
        LanguageType = questionDescription.LanguageType;
        Question = question;
        AnswerOptions = questionDescription.AnswerOptions.Select(x => new AnswerOptionState(x, this)).ToList();
    }

    public virtual Guid Id { get; set; }
    public virtual string Description { get; set; }
    public virtual LanguageType LanguageType { get; set; }
    public virtual IList<AnswerOptionState> AnswerOptions { get; set; }
    public virtual QuestionState Question { get; set; }
}