namespace Backend.Application.Commands.TypeRequirementCommands;

public class DeleteTypeRequirementCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; }

    public DeleteTypeRequirementCommand(Guid id)
    {
        Id = id;
    }
}