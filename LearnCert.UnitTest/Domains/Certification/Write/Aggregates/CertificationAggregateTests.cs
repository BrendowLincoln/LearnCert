using AutoFixture;
using LearnCert.Domain.Domains.Certification.Write.Aggregates;
using NUnit.Framework;

namespace LearnCert.UnitTest.Domains.Certification.Write.Aggregates;

public class CertificationAggregateTests : UnitTestBase
{

    [Test]
    public void ShouldCreateCertificationAggregate()
    {
        // Given
        var aggregate = Fixture.Create<CertificationAggregate>();
        
        // When

        // Then
        
    }
}