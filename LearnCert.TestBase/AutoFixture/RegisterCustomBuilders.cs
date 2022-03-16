using AutoFixture.Kernel;

namespace LearnCert.TestBase.AutoFixture;

public static class RegisterCustomBuilders
{

    public static CompositeSpecimenBuilder Register()
    {
        var builders =
            typeof(BaseBuilder).Assembly.
                GetTypes()
                .Where(x => x.BaseType == typeof(BaseBuilder))
                .Select(builder => Activator.CreateInstance(builder) as ISpecimenBuilder)
                .ToList();
        return new CompositeSpecimenBuilder(builders);
    }
    
}