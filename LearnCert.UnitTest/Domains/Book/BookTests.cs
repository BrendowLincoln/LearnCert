using AutoFixture;
using FluentAssertions;
using NUnit.Framework;

namespace LearnCert.UnitTest.Models.Book;

public class BookTests : UnitTestBase
{

    [Test]
    public void ShouldBeTrue()
    {
        // Given
        var book = Fixture.Create<Domain.Domains.Book.BookState>();
        
        // When
        var result = 1;
        
        // Then
        result.Should().Be(1);
    }
}