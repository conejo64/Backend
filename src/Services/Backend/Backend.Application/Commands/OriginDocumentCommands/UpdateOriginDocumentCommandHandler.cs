using Backend.Application.Commands.ProfileCommands;
using Backend.Application.Specifications.ProfileSpecs;

namespace Backend.Application.Commands.OriginDocumentCommands;

public class UpdateOriginDocumentCommandHandler : IRequestHandler<UpdateOriginDocumentCommand, EntityResponse<bool>>
{
    private readonly IRepository<OriginDocument> _repository;

    public UpdateOriginDocumentCommandHandler(IRepository<OriginDocument> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<bool>> Handle(UpdateOriginDocumentCommand command, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (entity == null)
        {
            return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
        }

        entity.Description = command.Description;

        await _repository.UpdateAsync(entity, cancellationToken);

        return true;
    }

}