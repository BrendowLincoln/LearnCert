using System.Collections;
using System.Reflection;
using AutoFixture.Kernel;
using LearnCert.Domain.Infrastructure;

namespace LearnCert.IntegrationTest;

public abstract class BaseBehaviour : ISpecimenBuilderNode
{
    protected ISpecimenBuilder Builder { get; }

    protected BaseBehaviour(ISpecimenBuilder builder)
    {
        Builder = builder;
    }

    public abstract object Create(object request, ISpecimenContext context);

    public IEnumerator<ISpecimenBuilder> GetEnumerator()
    {
        yield return Builder;
    }

    public ISpecimenBuilderNode Compose(IEnumerable<ISpecimenBuilder> builders)
    {
        var builder = CreateSingleBuilder(builders);
        return CreateBuilder(builder);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
   
    protected abstract ISpecimenBuilderNode CreateBuilder(ISpecimenBuilder builder);

    private static ISpecimenBuilder CreateSingleBuilder(IEnumerable<ISpecimenBuilder> builders)
    {
        return builders.Count() == 1 ? builders.Single() : new CompositeSpecimenBuilder(builders);
    }
    

}
