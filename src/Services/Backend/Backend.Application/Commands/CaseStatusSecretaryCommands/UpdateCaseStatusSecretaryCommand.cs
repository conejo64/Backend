namespace Backend.Application.Commands.CaseStatusSecretaryCommands
{
    public class UpdateCaseStatusSecretaryCommand : IRequest<EntityResponse<bool>>
    {
        public Guid Id { get; }
        public string Description { get; }

        public UpdateCaseStatusSecretaryCommand(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}