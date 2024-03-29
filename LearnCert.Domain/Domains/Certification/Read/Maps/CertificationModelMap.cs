﻿using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Domains.Certification.Write.States;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Read.Maps;

public class CertificationModelMap : ClassMap<CertificationModel>
{
    public CertificationModelMap()
    {
        ReadOnly();
        Table("Certification");
            
        Id(x => x.Id);
        Map(x => x.ImageUrl);
        Map(x => x.Title);
        Map(x => x.LanguageType).AsEnumString<LanguageType>();

        HasMany(x => x.Modules).KeyColumn("CertificationId");

    }
}