using AutoFixture.Kernel;

namespace LearnCert.UnitTest.AutoFixture;

public abstract class BaseBuilder : ISpecimenBuilder
{

    public object Create(object request, ISpecimenContext context)
    {
        if (request is Type && (Type) request == AppliableTo())
        {
            return CreateNew(context);
        }
        return new NoSpecimen();
    }
    
    protected abstract Type AppliableTo();
    
    protected abstract object CreateNew(ISpecimenContext context);
}