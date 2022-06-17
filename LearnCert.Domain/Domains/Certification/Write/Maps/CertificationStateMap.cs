using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Domains.Certification.Write.States;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Write.Maps;

public class CertificationStateMap : ClassMap<CertificationState>
{
    public CertificationStateMap()
    {
        Table("Certification");
            
        Id(x => x.Id).GeneratedBy.Assigned();
        Map(x => x.Title);
        Map(x => x.ImageUrl);
        Map(x => x.LanguageType).AsEnumString<LanguageType>();

        HasMany(x => x.Modules)
            .KeyColumn("CertificationId")
            .Cascade.AllDeleteOrphan()
            .Inverse();

    }
}