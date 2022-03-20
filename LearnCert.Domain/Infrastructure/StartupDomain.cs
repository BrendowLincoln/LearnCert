using System.Reflection;
using FluentMigrator.Runner;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LearnCert.Domain.Infraestructure.Persistence.Migrations;
using LearnCert.Domain.Infrastructure.Persistence;
using LearnCert.Domain.Infrastructure.Persistence.Connection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace LearnCert.Domain.Infrastructure;

public class StartupDomain
{
    private readonly IConfiguration _configuration;
    private readonly IServiceCollection _servicesCollection;
    
    public StartupDomain(IConfiguration configuration, IServiceCollection servicesCollection)
    {
        _configuration = configuration;
        _servicesCollection = servicesCollection;
    }
    
    public void Initialize()
    {
        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        _servicesCollection.AddSingleton<ILogger>(_ => logger);
        
        RegisterModules();

        var connectionString = new MySqlConnectionStringFactory(_configuration, logger).ConnectionString;
        
        var sessionFactory = Fluently.Configure()
            .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
            .Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
            .BuildSessionFactory();
        
        _servicesCollection.AddScoped(_ => sessionFactory.OpenSession());
        _servicesCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        var serviceProvider = _servicesCollection.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddMySql5()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(CreateBookTable).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
        
        serviceProvider.GetRequiredService<IMigrationRunner>().MigrateUp();
        
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
            dependencyInjection.Compose(_servicesCollection);
        });
    }
}