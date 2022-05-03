using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace LearnCert.Domain.Infrastructure.Persistence;

public static class FluentNHibernateExtensions
{

    public static PropertyPart AsEnumString<TEnum>(this PropertyPart propertyPart)
    {
        return propertyPart.CustomType<EnumStringType<TEnum>>();
    }
    
}