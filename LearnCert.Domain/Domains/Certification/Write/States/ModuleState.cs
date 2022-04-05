using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Infrastructure;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class ModuleState : BaseState
{
    public ModuleState()
    {
    }
    
    public ModuleState(ModuleValueObject module, Guid certificationId)
    {
        Id = module.Id;
        Title = module.Title;
        Order = module.Order;
        CertificationId = certificationId;
        Questions = module.Questions.Select(x => new QuestionState(x)).ToList();
    }

    public virtual Guid Id { get; set; }
    public virtual string Title { get; set; }
    public virtual int Order { get; set; }
    
    public virtual Guid CertificationId { get; set; }
    public virtual IList<QuestionState> Questions { get; set; }

}