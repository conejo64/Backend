using Backend.Application.Commands.TypeRequirementCommands;

namespace Backend.API.DTOs.Requests.TypeRequirementRequests;

public class UpdateTypeRequirementRequest
{
    public string Description { get; }

    public UpdateTypeRequirementRequest(string description)
    {
        Description = description;
    }

    public UpdateTypeRequirementCommand ToApplicationRequest(Guid id)
    {
        return new UpdateTypeRequirementCommand(id, Description);
    }
}