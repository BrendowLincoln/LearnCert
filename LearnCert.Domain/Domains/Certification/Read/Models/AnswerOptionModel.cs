using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class AnswerOptionModel : BaseModel
{
    public virtual Guid Id { get; set; }
    public virtual string Description { get; set; }
    public virtual int Code { get; set; }
    public virtual bool IsCorrect { get; set; }
}