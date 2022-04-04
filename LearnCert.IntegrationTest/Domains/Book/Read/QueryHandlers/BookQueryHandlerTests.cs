using AutoFixture;
using FluentAssertions;
using LearnCert.Domain.Domains.Book;
using LearnCert.Domain.Domains.Book.Read.QueryHandlers;
using NUnit.Framework;

namespace LearnCert.IntegrationTest.Domains.Book.Read.QueryHandlers;

public class BookQueryHandlerTests : IntegrationTestBase
{

    private IBookQueryHandler _sut;

    [SetUp]
    public void BookQueryHandlerTests_SetUp()
    {
        _sut = new BookQueryHandler(UnitOfWork);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void ShouldVerifyIfBookExistsByTitle(bool exists)
    {
        // Given
        var books = Fixture.CreateMany<BookState>().ToList();
        var title = "Hello";
        
        if (exists)
        {
            books[2].Title = title;
            UnitOfWork.Merge(books[2]);
        }
        
        // When
        var result = _sut.Exists(title);

        // Then
        result.Should().Be(exists);
    }
}