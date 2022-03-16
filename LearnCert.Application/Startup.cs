using LearnCert.Domain.Infrastructure;

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
        var domainModule = new StartupDomain(Configuration, services);
        domainModule.Initialize();
    }

}