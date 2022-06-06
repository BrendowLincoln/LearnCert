using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class CertificationModel : BaseModel
{
    public virtual string Title { get; set; }
    public virtual LanguageType LanguageType { get; set; }
    public virtual IList<QuestionModel> Questions { get; set; } = new List<QuestionModel>();

}
