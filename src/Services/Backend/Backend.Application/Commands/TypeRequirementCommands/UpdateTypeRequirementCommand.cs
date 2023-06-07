namespace Backend.Application.Commands.TypeRequirementCommands;

public class UpdateTypeRequirementCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; }
    public string Description { get; }

    public UpdateTypeRequirementCommand(Guid id, string description)
    {
        Id = id;
        Description = description;
    }
}