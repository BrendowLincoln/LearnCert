using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Write.States;

public class CertificationFlatModel : BaseModel
{
    public virtual string Title { get; set; }
    public virtual LanguageType LanguageType { get; set; }
    public virtual int CountQuestions { get; set; }
    public virtual string ImageUrl { get; set; }

}