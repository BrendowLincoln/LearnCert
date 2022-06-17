using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class QuestionModel : BaseModel
{
    public virtual Guid Id { get; set; }
    public virtual string Code { get; set; }
    public virtual string Description { get; set; }
    public virtual Guid ModuleId { get; set; }
    public virtual IList<AnswerOptionModel> AnswerOptions { get; set; }
}