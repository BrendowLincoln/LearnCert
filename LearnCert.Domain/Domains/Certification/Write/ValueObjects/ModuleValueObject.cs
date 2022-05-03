namespace LearnCert.Domain.Domains.Certification.Write.Enums;

public class ModuleValueObject
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Code { get; set; }
    public IList<QuestionValueObject> Questions { get; set; }

}