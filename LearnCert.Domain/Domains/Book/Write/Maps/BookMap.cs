using FluentNHibernate.Mapping;

namespace LearnCert.Domain.Domains.Book
{
    public class BookMap : ClassMap<BookState>
    {
        public BookMap()
        {
            Table("Book");
            
            Id(x => x.Id);
            Map(x => x.Title);
    
        }
    }
}