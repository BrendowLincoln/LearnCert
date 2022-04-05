namespace LearnCert.Domain.Domains.Certification.Write.Enums;

public class QuestionValueObject
{
    public Guid Id { get; set; }
    public int Code { get; set; }
    public IList<QuestionDescriptionValueObject> QuestionDescriptions { get; set; }

}