using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
namespace LearnCert.Api;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        /*
        var dynamoDbConfig = Configuration.GetSection("DynamoDb");
        var runLocalDynamoDb = dynamoDbConfig.GetValue<bool>("LocalMode");

        if (runLocalDynamoDb)
        {
            services.AddSingleton<IAmazonDynamoDB>(sp =>
            {
                var clientConfig = new AmazonDynamoDBConfig { ServiceURL = dynamoDbConfig.GetValue<string>("LocalServiceUrl") };
                return new AmazonDynamoDBClient(clientConfig);
            });
        }
        else
        {
            services.AddAWSService<IAmazonDynamoDB>();
        }
        */
            
        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        var sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
            .Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
            .BuildSessionFactory();
        
        services.AddScoped(_ => sessionFactory.OpenSession());
        RegisterModules(services);
    }

    private void RegisterModules(IServiceCollection services)
    {
        var dependencyInjectionModules = Assembly.Load("LearnCert.Api")
                                                        .GetTypes()
                                                        .Where(x => x.GetInterface(nameof(IDependencyInjection)) != null)
                                                        .ToList();
        dependencyInjectionModules.ForEach(x =>
        {
            var dependencyInjection = (IDependencyInjection) Activator.CreateInstance(x);
            dependencyInjection.Compose(services);
        });
    }
}