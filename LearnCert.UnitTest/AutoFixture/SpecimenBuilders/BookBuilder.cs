using AutoFixture;
using AutoFixture.Kernel;
using LearnCert.Domain;

namespace LearnCert.UnitTest.AutoFixture.SpecimentBuilders;

internal class BookBuilder : BaseBuilder
{
    
    protected override Type AppliableTo()
    {
        return typeof(Book);
    }

    protected override object CreateNew(ISpecimenContext context)
    {
        return new Book()
        {
            Id = context.Create<Guid>(),
            Title = "Hello 1"
        };
    }
}