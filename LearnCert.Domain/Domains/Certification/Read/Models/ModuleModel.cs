using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class ModuleModel : BaseModel
{
    public virtual Guid Id { get; set; }
    public virtual string Title { get; set; }
    public virtual int Code { get; set; }
    public virtual IList<QuestionModel> Questions { get; set; } = new List<QuestionModel>();
    public virtual Guid CertificationId { get; set; }
}