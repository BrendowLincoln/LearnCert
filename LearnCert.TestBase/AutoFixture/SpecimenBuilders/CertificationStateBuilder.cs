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
            var module = new ModuleState
            {
                Id = context.Create<Guid>(),
                Certification = certification,
                Code = context.Create<int>(),
                Title = context.Create<string>()
            };
            module.Questions = CreateQuestions(context, module);
            modules.Add(module);
        }
        return modules;
    }
    
    private IList<QuestionState> CreateQuestions(ISpecimenContext context, ModuleState module)
    {
        var questions = new List<QuestionState>();
        for (var i = 0; i < 3; i++)
        {
            var question = new QuestionState
            {
                Id = context.Create<Guid>(),
                Module = module,
                Code = context.Create<int>()
            };
            questions.Add(question);
        }
        return questions;
    }
}