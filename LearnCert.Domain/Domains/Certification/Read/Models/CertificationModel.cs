using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class CertificationModel : BaseModel
{
    public virtual string Title { get; set; }
    public virtual IList<QuestionDescriptionModel> QuestionDescriptions { get; set; } = new List<QuestionDescriptionModel>();

}
