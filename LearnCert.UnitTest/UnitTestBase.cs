using AutoFixture;
using LearnCert.TestBase.AutoFixture;
using NUnit.Framework;

namespace LearnCert.UnitTest;

public class UnitTestBase
{
    public Fixture Fixture { get; set; }
    
    [SetUp]
    public void SetupBase()
    {
        Fixture = new Fixture();
        Fixture.Customizations.Add(RegisterCustomBuilders.Register());
    }
}