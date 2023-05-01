using Backend.Application.Commands.DepartmentCommands;

namespace Backend.API.DTOs.Requests.DepartmentRequests;

public class CreateDepartmentRequest
{
    public string Description { get; }

    public CreateDepartmentRequest(string description)
    {
        Description = description;
    }

    public CreateDepartmentCommand ToApplicationRequest()
    {
        return new CreateDepartmentCommand(Description);
    }
}