using AutoFixture.Kernel;
using LearnCert.Domain.Infrastructure;
using LearnCert.Domain.Infrastructure.Persistence;
using LearnCert.IntegrationTest;

namespace LearnCert.TestBase.AutoFixture;

public class SaveEntityBehaviour : ISpecimenBuilderTransformation
{
    private readonly IUnitOfWork _unitOfWork;
    
    public SaveEntityBehaviour(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public ISpecimenBuilderNode Transform(ISpecimenBuilder builder)
    {
        return new SaveEntityNode(_unitOfWork, builder);
    }
}

public class SaveEntityNode : BaseBehaviour
{
    private readonly IUnitOfWork _unitOfWork;
    
    public SaveEntityNode(IUnitOfWork unitOfWork, ISpecimenBuilder builder): base(builder)
    {
        _unitOfWork = unitOfWork;
    }
    
    public override object Create(object request, ISpecimenContext context)
    {
        var specimen = Builder.Create(request, context);
        if (specimen is IBaseState entity)
        {
            return _unitOfWork.Merge(entity);
        }

        if (specimen is IAggregate<IBaseState> aggregate)
        {
            return _unitOfWork.Merge(aggregate.GetState());
        }

        return specimen;
    }

    protected override ISpecimenBuilderNode CreateBuilder(ISpecimenBuilder builder)
    {
        return new SaveEntityNode(_unitOfWork, builder);
    }
}