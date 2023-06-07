namespace Backend.Application.Commands.OriginDocumentCommands;

public class UpdateOriginDocumentCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; }
    public string Description { get; }

    public UpdateOriginDocumentCommand(Guid id, string description)
    {
        Id = id;
        Description = description;
    }
}