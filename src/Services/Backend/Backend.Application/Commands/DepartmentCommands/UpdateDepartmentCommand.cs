namespace Backend.Application.Commands.DepartmentCommands
{
    public class UpdateDepartmentCommand : IRequest<EntityResponse<bool>>
    {
        public Guid Id { get; }
        public string Description { get; }

        public UpdateDepartmentCommand(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}