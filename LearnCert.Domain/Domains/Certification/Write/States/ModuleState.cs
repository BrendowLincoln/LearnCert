using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Infrastructure;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class ModuleState : BaseState
{
    public ModuleState()
    {
    }
    
    public ModuleState(ModuleValueObject module, CertificationState certification)
    {
        Id = module.Id;
        Title = module.Title;
        Code = module.Code;
        Certification = certification;
        Questions = module.Questions.Select(x => new QuestionState(x, this)).ToList();
    }

    public virtual Guid Id { get; set; }
    public virtual string Title { get; set; }
    public virtual int Code { get; set; }
    public virtual IList<QuestionState> Questions { get; set; }
    public virtual CertificationState Certification { get; set; }
}