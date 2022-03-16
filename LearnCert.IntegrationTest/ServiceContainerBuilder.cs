using AutoFixture.Kernel;
using FluentMigrator.Runner;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LearnCert.Domain;
using LearnCert.Domain.Domains.Book;
using LearnCert.Domain.Infraestructure.Persistence.Migrations;
using LearnCert.Domain.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnCert.IntegrationTest;

public interface IServiceContainerBuilder : ISpecimenBuilder
{
    TServ GetInstance<TServ>();
}
public class ServiceContainerBuilder : IServiceContainerBuilder
{
    private static IServiceCollection Services;
    private static IServiceProvider ServiceProvider;
    private static IConfiguration Configuration;
    
    public ServiceContainerBuilder()
    {
        Services = new ServiceCollection();
        // TODO Create a fake IConfiguration and define a connection string to test database
        var connectionString = "Server=127.0.0.1;Database=learn_cert_db;Uid=root;Pwd=root;";
        
        var sessionFactory = Fluently.Configure()
            .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
            .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(BookMap).Assembly))
            .BuildSessionFactory();
        
        Services.AddScoped(_ => sessionFactory.OpenSession());
        Services.AddScoped<IUnitOfWork, UnitOfWork>();


        Services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddMySql5()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(CreateBookTable).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());
        
        ServiceProvider = Services.BuildServiceProvider();

        ServiceProvider.GetRequiredService<IMigrationRunner>().MigrateUp();
        
    }

    public TServ GetInstance<TServ>()
    {
        return ServiceProvider.GetService<TServ>();
    }
    
    public object Create(object request, ISpecimenContext context)
    {
        try
        {
            if (request is Type type)
            {
                return ServiceProvider.GetService(type);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return new NoSpecimen();
    }
}