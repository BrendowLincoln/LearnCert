using AutoFixture;
using FluentAssertions;
using NUnit.Framework;

namespace LearnCert.IntegrationTest.Domains.Book;

public class BookReadRepositoryTests : IntegrationTestBase
{

    [Test]
    public void ShouldCreateABook()
    {
        // Given
        var book = Fixture.Create<Domain.Domains.Book.BookState>();
        
        // When
        
        // Then
        book.Should().NotBeNull();
    }
}