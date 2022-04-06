using AutoFixture;
using FluentAssertions;
using LearnCert.Domain.Domains.Certification.Write.Aggregates;
using LearnCert.Domain.Domains.Certification.Write.Repositories;
using NUnit.Framework;

namespace LearnCert.IntegrationTest.Domains.Certification;

public class CertificationWriteRepositoryTests : IntegrationTestBase
{
    private ICertificationWriteRepository _sut;

    [SetUp]
    public void CertificationWriteRepositoryTests_SetUp()
    {
        _sut = new CertificationWriteRepository(UnitOfWork, RegisterProviderService);
    }
    
    [Test]
    public void ShouldCreateCertificationState()
    {
        // Given
        var certification = Fixture.Create<CertificationAggregate>();
        
        // When
        _sut.Save(certification);
        var result = _sut.GetById(certification.Id);

        // Then
        result.Id.Should().Be(certification.Id);
        result.GetState().Title.Should().Be(certification.GetState().Title);
    }
}