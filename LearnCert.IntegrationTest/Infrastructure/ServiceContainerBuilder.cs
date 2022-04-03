using AutoFixture.Kernel;
using FluentMigrator.Runner;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LearnCert.Domain.Domains.Book;
using LearnCert.Domain.Infraestructure.Persistence.Migrations;
using LearnCert.Domain.Infrastructure;
using LearnCert.Domain.Infrastructure.Persistence;
using LearnCert.Domain.Infrastructure.Persistence.Connection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace LearnCert.IntegrationTest;

public interface IServiceContainerBuilder : ISpecimenBuilder
{
    TServ GetInstance<TServ>();
}
public class ServiceContainerBuilder : IServiceContainerBuilder
{
    private static IServiceCollection _serviceCollection;
    private static IServiceProvider ServiceProvider;
    private static IConfiguration _configuration;

    private readonly ApplicationConstructor _applicationConstructor;
    
    public ServiceContainerBuilder()
    {
        _serviceCollection = new ServiceCollection();
        
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json");
        _configuration = config.Build();
        
        _applicationConstructor = new ApplicationConstructor(_configuration, _serviceCollection);
        _applicationConstructor.Initialize();
    }

    public TServ GetInstance<TServ>()
    {
        return _applicationConstructor.ServiceProvider.GetService<TServ>();
    }
    
    public object Create(object request, ISpecimenContext context)
    {
        try
        {
            if (request is Type type)
            {
                return _applicationConstructor.ServiceProvider.GetService(type);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return new NoSpecimen();
    }
}