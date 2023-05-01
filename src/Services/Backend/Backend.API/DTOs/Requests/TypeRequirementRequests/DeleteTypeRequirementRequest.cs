using Backend.Application.Commands.TypeRequirementCommands;
using Backend.Domain.SeedWork;

namespace Backend.API.DTOs.Requests.TypeRequirementRequests;

public class DeleteTypeRequirementRequest
{
    public DeleteTypeRequirementCommand ToApplicationRequest(Guid id)
    {
        return new DeleteTypeRequirementCommand(id);
    }
}