using Backend.Application.Commands.DepartmentCommands;

namespace Backend.API.DTOs.Requests.DepartmentRequests;

public class UpdateDepartmentRequest
{
    public string Description { get; }

    public UpdateDepartmentRequest(string description)
    {
        Description = description;
    }

    public UpdateDepartmentCommand ToApplicationRequest(Guid id)
    {
        return new UpdateDepartmentCommand(id, Description);
    }
}