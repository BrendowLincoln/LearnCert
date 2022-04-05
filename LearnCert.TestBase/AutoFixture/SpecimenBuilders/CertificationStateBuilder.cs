using AutoFixture;
using AutoFixture.Kernel;
using LearnCert.Domain;
using LearnCert.Domain.Domains.Book;
using LearnCert.Domain.Domains.Certification.Write.States;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.TestBase.AutoFixture.SpecimenBuilders;

internal class CertificationStateBuilder : BaseBuilder
{
    
    protected override Type AppliableTo()
    {
        return typeof(CertificationState);
    }

    protected override object CreateNew(ISpecimenContext context)
    {
        var certification = new CertificationState
        {
            Id = context.Create<Guid>(),
            Title = context.Create<string>(),
        };

        certification.Modules = CreateModules(context, certification);
        return certification;
    }

    private IList<ModuleState> CreateModules(ISpecimenContext context, CertificationState certification)
    {
        var modules = new List<ModuleState>();
        for (var i = 0; i < 3; i++)
        {
            modules.Add(new ModuleState
            {
                Id = context.Create<Guid>(),
                Certification = certification, 
                Order = context.Create<int>(),
                Title = context.Create<string>()
            });
        }

        return modules;
    }
}