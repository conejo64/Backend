using Backend.Application.Commands.ProfileCommands;
using Backend.Application.Specifications.ProfileSpecs;

namespace Backend.Application.Commands.BrandCommands;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, EntityResponse<bool>>
{
    private readonly IRepository<Brand> _repository;

    public UpdateBrandCommandHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<bool>> Handle(UpdateBrandCommand command, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (entity == null)
        {
            return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.BrandNotFound));
        }

        entity.Description = command.Description;

        await _repository.UpdateAsync(entity, cancellationToken);

        return true;
    }

}