namespace LearnCert.Domain.Infrastructure.Validation;

public class DomainException : System.Exception
{
    public DomainException(string message = null) : base(message)
    {
    }
    
}