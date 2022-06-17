using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Domains.Certification.Write.States;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Read.Maps;

public class CertificationFlatModelMap : ClassMap<CertificationFlatModel>
{
    public CertificationFlatModelMap()
    {
        ReadOnly();
        Table("CertificationFlatView");
            
        Id(x => x.Id);
        Map(x => x.Title);
        Map(x => x.ImageUrl);
        Map(x => x.CountQuestions);
        Map(x => x.LanguageType).AsEnumString<LanguageType>();


    }
}