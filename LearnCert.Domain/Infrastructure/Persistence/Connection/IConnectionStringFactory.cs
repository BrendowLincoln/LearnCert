namespace LearnCert.Domain.Infrastructure.Persistence.Connection;

public interface IConnectionStringFactory
{
    public string ConnectionString { get; }
}