namespace Backend.Application.Commands.DepartmentCommands;

public class CreateDepartmentCommand : IRequest<EntityResponse<Guid>>
{
    public string Description { get; }

    public CreateDepartmentCommand(string description)
    {
        Description = description;
    }
}