namespace LearnCert.Domain.Infrastructure.Validation;


public class DomainException<T> : System.Exception
{
    public DomainException(string message = null) : base(message)
    {
    }
    
}