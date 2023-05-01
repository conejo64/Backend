namespace Backend.Application.Commands.DepartmentCommands
{
    public class DeleteDepartmentCommand : IRequest<EntityResponse<bool>>
    {
        public Guid Id { get; }

        public DeleteDepartmentCommand(Guid id)
        {
            Id = id;
        }
    }
}