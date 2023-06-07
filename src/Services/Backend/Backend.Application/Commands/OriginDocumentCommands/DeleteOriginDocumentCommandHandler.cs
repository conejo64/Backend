namespace Backend.Application.Commands.OriginDocumentCommands;

public class DeleteOriginDocumentCommandHandler : IRequestHandler<DeleteOriginDocumentCommand, EntityResponse<bool>>
{
    private readonly IRepository<OriginDocument> _repository;

    public DeleteOriginDocumentCommandHandler(IRepository<OriginDocument> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<bool>> Handle(DeleteOriginDocumentCommand command, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (entity == null)
        {
            return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
        }

        entity.Status = CatalogsStatus.Deleted;

        await _repository.UpdateAsync(entity, cancellationToken);

        return true;
    }

}