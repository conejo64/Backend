namespace Backend.Application.Commands.CaseStatusSecretaryCommands
{
    public class DeleteCaseStatusSecretaryCommand : IRequest<EntityResponse<bool>>
    {
        public Guid Id { get; }

        public DeleteCaseStatusSecretaryCommand(Guid id)
        {
            Id = id;
        }
    }
}