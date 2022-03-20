using Microsoft.Extensions.Configuration;
using Serilog;

namespace LearnCert.Domain.Infrastructure.Persistence.Connection;

public class MySqlConnectionStringFactory : IConnectionStringFactory
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;
    
    private string Host => _configuration["DBHOST"] ?? "127.0.0.1";
    private int Port => 3306;
    private string Database => _configuration["MYSQL_DATABASE"];
    private string Password => _configuration["MYSQL_PASSWORD"];

    private string UserId => _configuration["MYSQL_USER"];
    
    public MySqlConnectionStringFactory(IConfiguration configuration, ILogger logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public string ConnectionString {
        get
        {
            _logger.Information("MySqlConnectionString running on {@Host}:{@Port}, Database: {@Database} - User: {@UserId} - Password: {@Password}", Host, Port, Database, UserId, Password);
            return $"Server={Host};port={Port};Database={Database};Uid={UserId};Pwd={Password};";
        }
} 
}