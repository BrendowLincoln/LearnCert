using AutoFixture;
using AutoFixture.Kernel;
using LearnCert.Domain;
using LearnCert.Domain.Domains.Book;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.TestBase.AutoFixture.SpecimenBuilders;

internal class BookStateBuilder : BaseBuilder
{
    
    protected override Type AppliableTo()
    {
        return typeof(BookState);
    }

    protected override object CreateNew(ISpecimenContext context)
    {
        return new BookState()
        {
            Id = context.Create<Guid>(),
            Title = context.Create<string>()
        };
    }

}