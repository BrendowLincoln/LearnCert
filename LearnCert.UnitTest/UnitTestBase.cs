using AutoFixture;
using AutoFixture.Kernel;
using LearnCert.UnitTest.AutoFixture;
using NUnit.Framework;

namespace LearnCert.UnitTest;

public class UnitTestBase
{
    public Fixture Fixture { get; set; }
    
    [SetUp]
    public void SetupBase()
    {
        Fixture = new Fixture();
        
        var builders =
            typeof(BaseBuilder).Assembly.
                GetTypes()
                .Where(x => x.BaseType == typeof(BaseBuilder))
                .Select(builder => Activator.CreateInstance(builder) as ISpecimenBuilder)
                .ToList();
        
        Fixture.Customizations.Add(new CompositeSpecimenBuilder(builders));
    }
}