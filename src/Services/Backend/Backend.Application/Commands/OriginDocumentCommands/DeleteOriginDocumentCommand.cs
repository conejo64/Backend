namespace Backend.Application.Commands.OriginDocumentCommands;

public class DeleteOriginDocumentCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; }

    public DeleteOriginDocumentCommand(Guid id)
    {
        Id = id;
    }
}