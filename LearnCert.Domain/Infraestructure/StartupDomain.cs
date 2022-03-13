using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LearnCert.Domain.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnCert.Domain.Infraestructure;

public class RegisterDomain
{
    private IConfiguration Configuration { get; }
    private IServiceCollection Services { get; }
    
    public RegisterDomain(IConfiguration configuration, IServiceCollection services)
    {
        Configuration = configuration;
        Services = services;
    }
    
    public void Initialize()
    {
        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        
        var sessionFactory = Fluently.Configure()
            .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
            .Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
            .BuildSessionFactory();
        
        Services.AddScoped(_ => sessionFactory.OpenSession());
        Services.AddScoped<IUnitOfWork, UnitOfWork>();

        RegisterModules();
    }
    
    private void RegisterModules()
    {
        var dependencyInjectionModules = Assembly.Load("LearnCert.Domain")
            .GetTypes()
            .Where(x => x.GetInterface(nameof(IDependencyInjection)) != null)
            .ToList();
        dependencyInjectionModules.ForEach(x =>
        {
            var dependencyInjection = (IDependencyInjection) Activator.CreateInstance(x);
            dependencyInjection.Compose(Services);
        });
    }
}