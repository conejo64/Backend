namespace Backend.Application.Commands.CaseStatusCommands
{
    public class DeleteCaseStatusCommand : IRequest<EntityResponse<bool>>
    {
        public Guid Id { get; }

        public DeleteCaseStatusCommand(Guid id)
        {
            Id = id;
        }
    }
}