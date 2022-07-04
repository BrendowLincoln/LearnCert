using LearnCert.Domain.Domains.Certification.Write.Commands;
using LearnCert.Domain.Domains.Certification.Write.Enums;
using LearnCert.Domain.Domains.Certification.Write.States;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Write.Aggregates;

public interface ICertificationAggregate : IAggregate<CertificationState>
{
}

public class CertificationAggregate : BaseAggregate<CertificationState>, ICertificationAggregate
{
    
    public CertificationAggregate(CertificationState state)
    {
        State = state;
    }

    public CertificationAggregate(CreateCertificationCommand cmd)
    {
        State = new CertificationState
        {
            Id = cmd.Id,
            Title = cmd.Title,
            ImageUrl = cmd.ImageUrl
        };
        State.Modules = cmd.Modules.Select(x => SaveModule(x, true)).ToList();
    }

    public void Change(UpdateCertificationCommand cmd)
    {
        State.Title = cmd.Title;
        State.ImageUrl = cmd.ImageUrl;
        State.Modules = cmd.Modules.Select(x => SaveModule(x)).ToList();
    }

    private ModuleState SaveModule(ModuleValueObject module, bool isNew = false)
    {
        if (isNew)
        {
            return new ModuleState(module, State);
        }

        var moduleAlreadyAdded = State.Modules.First(x => x.Id == module.Id);
        if (moduleAlreadyAdded == null)
        {
            return new ModuleState(module, State);
        }

        moduleAlreadyAdded.Title = module.Title;
        moduleAlreadyAdded.Questions = module.Questions.Select(x => SaveQuestion(x, moduleAlreadyAdded)).ToList();
        
        return moduleAlreadyAdded;
    }

    private QuestionState SaveQuestion(QuestionValueObject question, ModuleState moduleState)
    {
        var questionAlreadyAdded = moduleState.Questions.First(x => x.Id == question.Id);
        if (questionAlreadyAdded == null)
        {
            return new QuestionState(question, moduleState);
        }

        questionAlreadyAdded.Description = question.Description;
        questionAlreadyAdded.AnswerOptions =
            question.AnswerOptions.Select(x => SaveAnswerOption(x, questionAlreadyAdded)).ToList();
        return questionAlreadyAdded;
    }

    private AnswerOptionState SaveAnswerOption(AnswerOptionValueObject answerOption, QuestionState questionState)
    {
        var answerAlreadyAdded = questionState.AnswerOptions.First(x => x.Id == answerOption.Id);
        if (answerAlreadyAdded == null)
        {
            return new AnswerOptionState(answerOption, questionState);
        }

        answerAlreadyAdded.Description = answerOption.Description;
        answerAlreadyAdded.IsCorrect = answerOption.IsCorrect;

        return answerAlreadyAdded;
    }
}