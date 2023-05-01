namespace Backend.Application.Commands.CaseStatusCommands

{
    public class CreateCaseStatusCommand : IRequest<EntityResponse<Guid>>
    {
        public string Description { get; }

        public CreateCaseStatusCommand(string description)
        {
            Description = description;
        }
    }
}