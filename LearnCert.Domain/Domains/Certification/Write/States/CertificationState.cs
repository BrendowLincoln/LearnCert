using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Infrastructure;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class  CertificationState : BaseState
{
    public virtual string Title { get; set; }
    public virtual LanguageType LanguageType { get; set; }
    public virtual IList<ModuleState> Modules { get; set; } = new List<ModuleState>();

}