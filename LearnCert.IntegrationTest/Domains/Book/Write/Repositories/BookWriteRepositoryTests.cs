using AutoFixture;
using FluentAssertions;
using LearnCert.Domain.Domains.Book;
using LearnCert.Domain.Infrastructure.Persistence;
using NSubstitute;
using NUnit.Framework;

namespace LearnCert.IntegrationTest.Domains.Book.Write.Repositories;

public class BookWriteRepositoryTests : IntegrationTestBase
{

    private IBookWriteRepository _sut;

    [SetUp]
    public void BookWriteRepositoryTests_SetUp()
    {
        _sut = new BookWriteRepository(UnitOfWork, RegisterProviderService);
    }
    
    [Test]
    public void ShouldCreateBookState()
    {
        // Given
        var book = Fixture.Create<BookAggregate>();
        
        // When
        _sut.Save(book);
        var result = _sut.GetById(book.Id);

        // Then
        result.Id.Should().Be(book.Id);
        result.GetState().Title.Should().Be(book.GetState().Title);
    }
    
    [Test]
    public void ShouldChangeBookState()
    {
        // Given
        var book = Fixture.Create<BookAggregate>();
        var previousTitle = book.GetState().Title;
        book.GetState().Title = "hello new";
        
        // When
        _sut.Save(book);
        var result = _sut.GetById(book.Id);

        // Then
        result.Id.Should().Be(book.Id);
        result.GetState().Title.Should().Be(book.GetState().Title);
        previousTitle.Should().NotBe(result.GetState().Title);
    }
}