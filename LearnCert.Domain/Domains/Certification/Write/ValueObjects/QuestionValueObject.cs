namespace LearnCert.Domain.Domains.Certification.Write.Enums;

public class QuestionValueObject
{
    public Guid Id { get; set; }
    public int Code { get; set; }    
    public string Description { get; set; }
    public IList<AnswerOptionValueObject> AnswerOptions { get; set; }

}