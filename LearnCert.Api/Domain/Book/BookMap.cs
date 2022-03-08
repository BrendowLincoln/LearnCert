using FluentNHibernate.Mapping;

namespace LearnCert.Api
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Table("Book");
            
            Id(x => x.Id);
            Map(x => x.Title);
    
        }
    }
}