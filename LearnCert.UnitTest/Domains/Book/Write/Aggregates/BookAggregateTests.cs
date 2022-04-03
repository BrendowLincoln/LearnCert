using AutoFixture;
using FluentAssertions;
using LearnCert.Domain.Domains.Book;
using NUnit.Framework;

namespace LearnCert.UnitTest.Models.Book.Write.Aggregates;

public class BookAggregateTests : UnitTestBase
{

    [Test]
    public void ShouldCreateBookAggregateWithCreateBookCommand()
    {
        // Given
        var cmd = Fixture.Create<CreateBookCommand>();
        
        // When
        var aggregate = new BookAggregate(cmd);

        // Then
        aggregate.Id.Should().Be(cmd.Id);
        aggregate.GetState().Title.Should().Be(cmd.Title);
    }
    
    [Test]
    public void ShouldChangeBookAggregateWithChangeBookCommand()
    {
        // Given
        var state = Fixture.Create<BookState>();
        var cmd = Fixture.Create<ChangeBookCommand>();
        cmd.Id = state.Id;
        
        var aggregate = new BookAggregate(state);
        
        // When
        aggregate.Change(cmd);

        // Then
        aggregate.Id.Should().Be(state.Id);
        aggregate.GetState().Title.Should().Be(cmd.Title);
    }

}