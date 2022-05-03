using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class QuestionDescriptionModel : BaseModel
{
    public virtual Guid Id { get; set; }
    public virtual string Code { get; set; }
    public virtual string Description { get; set; }
    public virtual LanguageType LanguageType { get; set; }
    public virtual Guid CertificationId { get; set; }
    public virtual string ModuleTitle { get; set; }    
    public virtual Guid QuestionId { get; set; }
    public virtual IList<AnswerOptionModel> AnswerOptions { get; set; }
}