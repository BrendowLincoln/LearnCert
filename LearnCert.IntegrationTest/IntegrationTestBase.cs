using AutoFixture;
using LearnCert.Domain.Infrastructure.Persistence;
using LearnCert.IntegrationTest.Infrastructure;
using LearnCert.TestBase.AutoFixture;
using NHibernate;
using NUnit.Framework;

namespace LearnCert.IntegrationTest;

public class IntegrationTestBase
{
    public Fixture Fixture { get; set; }
    
    public IUnitOfWork UnitOfWork { get; set; }
    
    public IRegisterProviderService RegisterProviderService { get; set; }
    
    [SetUp]
    public void SetupBase()
    {
        Fixture = new Fixture();
        Fixture.Customizations.Add(RegisterCustomBuilders.Register());

        var serviceContainerBuilder = new ServiceContainerBuilder();
        Fixture.Behaviors.Add(new SaveEntityBehaviour(serviceContainerBuilder.GetInstance<IUnitOfWork>()));

        UnitOfWork = serviceContainerBuilder.GetInstance<IUnitOfWork>();
        RegisterProviderService = serviceContainerBuilder.GetInstance<IRegisterProviderService>();
        
        ResetDatabase.Init(UnitOfWork, "learn_cert_db_test");
    }
}