namespace Backend.Application.Commands.CaseStatusSecretaryCommands

{
    public class CreateCaseStatusSecretaryCommand : IRequest<EntityResponse<Guid>>
    {
        public string Description { get; }

        public CreateCaseStatusSecretaryCommand(string description)
        {
            Description = description;
        }
    }
}