using AutoFixture;
using FluentAssertions;
using LearnCert.Domain.Domains.Book;
using LearnCert.Domain.Infrastructure.Validation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace LearnCert.UnitTest.Models.Book.Write.CommandHandlers;

public class BookCommandHandlerTests : UnitTestBase
{

    private IBookWriteRepository _bookWriteRepository;
    private IBookReadRepository _bookReadRepository;
    private IBookValidator _bookValidator;
    private BookCommandHandler _sut;

    [SetUp]
    public void BookCommandHandlerTestsSetUp()
    {
        _bookWriteRepository = Substitute.For<IBookWriteRepository>();
        _bookReadRepository = Substitute.For<IBookReadRepository>();
        _bookValidator = new BookValidator(_bookReadRepository);
        
        _sut = new BookCommandHandler(_bookWriteRepository, _bookValidator);
    }

    [Test]
    public void ShouldHandleCreateBookCommand()
    {
        // Given
        var cmd = Fixture.Create<CreateBookCommand>();
        cmd.Title = "hello";
        
        // When
        _sut.Handle(cmd);
        
        // Then
        _bookWriteRepository.Received(1)
            .Save(Arg.Is<BookAggregate>(x => 
                x.Id == cmd.Id &&
                x.GetState().Title == cmd.Title)
            );
    }
    
    [Test]
    public void ShouldHandleChangeBookCommand()
    {
        // Given
        var aggregate = Fixture.Create<BookAggregate>();
        var cmd = Fixture.Create<ChangeBookCommand>();
        cmd.Title = "hello";
        
        _bookWriteRepository.GetById(cmd.Id).Returns(aggregate);
        
        // When
        _sut.Handle(cmd);
        
        // Then
        _bookWriteRepository.Received(1)
            .Save(Arg.Is<BookAggregate>(x => 
                x.Id == aggregate.Id &&
                x.GetState().Title == cmd.Title)
            );
    }
    
    [Test]
    public void ShouldHandleChangeBookCommandWithBookNotFound()
    {
        // Given
        var cmd = Fixture.Create<ChangeBookCommand>();

        _bookWriteRepository.GetById(cmd.Id).ReturnsNull();
        
        // When
        Action action = () => _sut.Handle(cmd);
        
        // Then
        action.Should().Throw<DomainException<IBookAggregate>>().WithMessage(BookExceptionCodes.BookNotFound);
        _bookWriteRepository.Received(0).Save(Arg.Any<BookAggregate>());
    }
    
    [Test]
    public void ShouldHandleCreateBookCommandWithTitleNotInformed()
    {
        // Given
        var cmd = Fixture.Create<CreateBookCommand>();
        cmd.Title = null;
        
        // When
        Action action = () => _sut.Handle(cmd);
        
        // Then
        action.Should().Throw<DomainException<IBookAggregate>>().WithMessage(BookExceptionCodes.TitleNotInformed);
        _bookWriteRepository.Received(0).Save(Arg.Any<BookAggregate>());
    }
    
    [TestCase("t")]
    [TestCase("tsadafsafasgvsdssgsdhgshdsfhs")]
    public void ShouldHandleChangeBookCommandWithTitleMustBeGreaterThanTwoAndLessThanTen(string title)
    {
        // Given
        var aggregate = Fixture.Create<BookAggregate>();
        var cmd = Fixture.Create<ChangeBookCommand>();
        cmd.Title = title;

        _bookWriteRepository.GetById(cmd.Id).Returns(aggregate);
        
        // When
        Action action = () => _sut.Handle(cmd);
        
        // Then
        action.Should().Throw<DomainException<IBookAggregate>>().WithMessage(BookExceptionCodes.TitleMustBeGreaterThanTwoAndLessThanTen);
        _bookWriteRepository.Received(0).Save(Arg.Any<BookAggregate>());
    }
    
    [Test]
    public void ShouldHandleCreateBookCommandWithTitleAlreadyUsed()
    {
        // Given
        var cmd = Fixture.Create<CreateBookCommand>();
        cmd.Title = "hello";
        
        _bookReadRepository.Exists(cmd.Title).Returns(true);
        
        // When
        Action action = () => _sut.Handle(cmd);
        
        // Then
        action.Should().Throw<DomainException<IBookAggregate>>().WithMessage(BookExceptionCodes.TitleAlreadyUsed);
        _bookWriteRepository.Received(0).Save(Arg.Any<BookAggregate>());
    }
}