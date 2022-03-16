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
        var builder = ComposeIfMultiple(builders);
        return CreateBuilder(builder);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
   
    protected abstract ISpecimenBuilderNode CreateBuilder(ISpecimenBuilder builder);

    private static ISpecimenBuilder ComposeIfMultiple(IEnumerable<ISpecimenBuilder> builders)
    {
        var isSingle = builders.Take(2).Count() == 1;
        if (isSingle)
            return builders.Single();

        return new CompositeSpecimenBuilder(builders);
    }
    
    protected bool IsEntityCollection(PropertyInfo prop)
    {
        return prop.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)) &&
               prop.PropertyType.IsGenericType &&
               prop.PropertyType.GetGenericArguments()[0].GetInterfaces().Contains(typeof(IBaseState));
    }
    
    protected bool IsDictionary(PropertyInfo prop)
    {
        return prop.PropertyType.GetInterfaces().Contains(typeof (IDictionary));
    }
    
    protected bool IsEntity(PropertyInfo prop)
    {
        return prop.PropertyType.GetInterfaces().Contains(typeof(IBaseState));
    }

}
