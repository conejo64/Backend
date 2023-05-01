using Backend.Application.Commands.TypeRequirementCommands;

namespace Backend.API.DTOs.Requests.TypeRequirementRequests;

public class CreateTypeRequirementRequest
{
    public string Description { get; }

    public CreateTypeRequirementRequest(string description)
    {
        Description = description;
    }

    public CreateTypeRequirementCommand ToApplicationRequest()
    {
        return new CreateTypeRequirementCommand(Description);
    }
}