using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.States;

namespace LearnCert.Domain.Domains.Certification.Read.Maps;

public class ModuleModelMap : ClassMap<ModuleModel>
{
    public ModuleModelMap()
    {
        ReadOnly();
        Table("Module");
            
        Id(x => x.Id);
        Map(x => x.Title);
        Map(x => x.Code);
        Map(x => x.CertificationId);

        HasMany(x => x.Questions).KeyColumn("ModuleId");

    }
}