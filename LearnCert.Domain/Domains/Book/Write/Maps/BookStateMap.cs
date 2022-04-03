using FluentNHibernate.Mapping;

namespace LearnCert.Domain.Domains.Book
{
    public class BookStateMap : ClassMap<BookState>
    {
        public BookStateMap()
        {
            Table("Book");
            
            Id(x => x.Id);
            Map(x => x.Title);
    
        }
    }
}