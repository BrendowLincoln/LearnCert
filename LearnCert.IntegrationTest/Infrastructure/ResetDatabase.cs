using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.IntegrationTest.Infrastructure;

public static class ResetDatabase
{
    
    // TODO - It needs test to tables with foreign keys when truncate
    public static void Init(IUnitOfWork unitOfWork, string database)
    {
        var namedQuery = unitOfWork.GetNamedQuery("GetAllTruncateTables");
        namedQuery.SetParameter("schema", database);
        
        var commands = namedQuery.List<string>().ToList();
        unitOfWork.ExecuteQuery(string.Join(";", commands)).ExecuteUpdate();
    }
}