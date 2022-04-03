using FluentNHibernate.Mapping;
using LearnCert.Domain.Domains.Book.Read.Models;

namespace LearnCert.Domain.Domains.Book.Read.Maps;

public class BookModelMap : ClassMap<BookModel>
{
    public BookModelMap()
    {
        Table("Book");
        ReadOnly();
            
        Id(x => x.Id);
        Map(x => x.Title);
    }
}