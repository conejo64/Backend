using Backend.Application.Commands.CaseStatusCommands;

namespace Backend.API.DTOs.Requests.CaseStatusRequests;

public class UpdateCaseStatusRequest
{
    public string Description { get; }

    public UpdateCaseStatusRequest(string description)
    {
        Description = description;
    }

    public UpdateCaseStatusCommand ToApplicationRequest(Guid id)
    {
        return new UpdateCaseStatusCommand(id, Description);
    }
}