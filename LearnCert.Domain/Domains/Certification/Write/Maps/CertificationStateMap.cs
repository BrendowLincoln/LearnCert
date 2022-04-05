using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.States;

namespace LearnCert.Domain.Domains.Certification.Write.Maps;

public class CertificationStateMap : ClassMap<CertificationState>
{
    public CertificationStateMap()
    {
        Table("Certification");
            
        Id(x => x.Id).GeneratedBy.Assigned();
        Map(x => x.Title);

        HasMany(x => x.Modules)
            .KeyColumn("CertificationId")
            .Cascade.AllDeleteOrphan()
            .Inverse();

    }
}