namespace Backend.Application.Commands.TypeRequirementCommands

{
    public class CreateTypeRequirementCommand : IRequest<EntityResponse<Guid>>
    {
        public string Description { get; }

        public CreateTypeRequirementCommand(string description)
        {
            Description = description;
        }
    }
}