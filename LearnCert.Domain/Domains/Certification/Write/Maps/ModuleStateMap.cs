using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.States;

namespace LearnCert.Domain.Domains.Certification.Write.Maps;

public class ModuleStateMap : ClassMap<ModuleState>
{
    public ModuleStateMap()
    {
        Table("Module");
            
        Id(x => x.Id).GeneratedBy.Assigned();
        Map(x => x.Title);
        Map(x => x.Code);

        References(x => x.Certification, "CertificationId");
        
        HasMany(x => x.Questions)
            .KeyColumn("ModuleId")
            .Cascade.AllDeleteOrphan()
            .Inverse();

    }
}