namespace LearnCert.Domain.Infrastructure.Persistence;

public interface IBaseModel
{
    Guid Id { get; set; }
}

public class BaseModel : IBaseModel
{
    public virtual Guid Id { get; set; }
}