using FluentMigrator.Builders.Create.Table;

namespace LearnCert.Domain.Infrastructure.Persistence;

public static class CreateTableColumnAsTypeSyntaxExtension
{
    public static ICreateTableColumnOptionOrWithColumnSyntax AsUUID(this ICreateTableColumnAsTypeSyntax x) 
    {
        return x.AsString(36);
    }
}