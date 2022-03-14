using System.Reflection;
using FluentMigrator.Runner;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LearnCert.Domain.Infraestructure.Persistence.Migrations;
using LearnCert.Domain.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnCert.Domain.Infrastructure;

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
        
        var serviceProvider = Services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddMySql5()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(CreateBookTable).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
        
        serviceProvider.GetRequiredService<IMigrationRunner>().MigrateUp();
        
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