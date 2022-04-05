namespace LearnCert.Domain.Domains.Certification.Write.Enums;

public class AnswerOptionValueObject
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool IsCorrect { get; set; }
}