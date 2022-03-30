namespace LearnCert.Domain.Infrastructure.Exception;

public class DomainException : System.Exception
{
    public DomainException(string message = null) : base(message)
    {
    }
    
}