namespace LearnCert.Domain.Domains.Certification.Write.Enums;

public class QuestionDescriptionValueObject
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public LanguageType LanguageType { get; set; }

}