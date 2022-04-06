using LearnCert.Domain.Domains.Certification.Write.Commands;
using LearnCert.Domain.Domains.Certification.Write.States;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Write.Aggregates;

public interface ICertificationAggregate : IAggregate<CertificationState>
{
}

public class CertificationAggregate : BaseAggregate<CertificationState>, ICertificationAggregate
{
    
    public CertificationAggregate(CertificationState state)
    {
        State = state;
    }

    public CertificationAggregate(CreateCertificationCommand cmd)
    {
        State = new CertificationState
        {
            Id = cmd.Id,
            Title = cmd.Title
        };
        State.Modules = cmd.Modules.Select(x => new ModuleState(x, State)).ToList();
    }
}