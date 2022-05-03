using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.States;

namespace LearnCert.Domain.Domains.Certification.Read.Maps;

public class CertificationModelMap : ClassMap<CertificationModel>
{
    public CertificationModelMap()
    {
        Table("Certification");
            
        Id(x => x.Id);
        Map(x => x.Title);

        HasMany(x => x.QuestionDescriptions).KeyColumn("CertificationId");

    }
}