using AutoFixture;
using AutoFixture.Kernel;
using LearnCert.Domain.Domains.Certification.Write.States;

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
                OrderExibition = context.Create<int>(),
                Title = context.Create<string>()
            });
        }

        return modules;
    }
}