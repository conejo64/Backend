namespace Backend.Application.Commands.CaseStatusCommands
{
    public class UpdateCaseStatusCommand : IRequest<EntityResponse<bool>>
    {
        public Guid Id { get; }
        public string Description { get; }

        public UpdateCaseStatusCommand(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}