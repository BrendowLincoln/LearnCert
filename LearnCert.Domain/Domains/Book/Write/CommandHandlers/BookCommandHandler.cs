using FluentValidation;
using LearnCert.Domain.Infrastructure.CQRS;
using LearnCert.Domain.Infrastructure.Validation;

namespace LearnCert.Domain.Domains.Book;

public class BookCommandHandler : ICommandHandler<CreateBookCommand>, ICommandHandler<ChangeBookCommand>
{
    
    private readonly IBookWriteRepository _bookWriteRepository;
    private readonly IBookValidator _bookValidator;

    public BookCommandHandler(IBookWriteRepository bookWriteRepository, IBookValidator bookValidator)
    {
        _bookWriteRepository = bookWriteRepository;
        _bookValidator = bookValidator;
    }
    
    public void Handle(CreateBookCommand cmd)
    {
        var aggregate = new BookAggregate(cmd);
        _bookValidator.ValidateDomainAndThrow(aggregate);
        _bookWriteRepository.Save(aggregate);
    }

    public void Handle(ChangeBookCommand cmd)
    {
        var aggregate = _bookWriteRepository.GetById(cmd.Id);
        _bookValidator.CustomValidateDomainAndThrow(aggregate);
        aggregate.Change(cmd);
        _bookValidator.ValidateDomainAndThrow(aggregate);
        _bookWriteRepository.Save(aggregate);
    }
}