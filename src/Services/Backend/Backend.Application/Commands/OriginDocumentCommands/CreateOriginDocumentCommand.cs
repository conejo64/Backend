namespace Backend.Application.Commands.OriginDocumentCommands
{
    public class CreateOriginDocumentCommand : IRequest<EntityResponse<Guid>>
    {
        public string Description { get; }

        public CreateOriginDocumentCommand(string description)
        {
            Description = description;
        }
    }
}