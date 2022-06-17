using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Infrastructure.CQRS;

namespace LearnCert.Domain.Domains.Certification.Write.Commands;

public class CreateCertificationCommand : ICommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public IList<ModuleValueObject> Modules { get; set; }
}
