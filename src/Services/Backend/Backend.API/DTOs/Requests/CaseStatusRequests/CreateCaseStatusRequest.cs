using Backend.Application.Commands.CaseStatusCommands;

namespace Backend.API.DTOs.Requests.CaseStatusRequests;

public class CreateCaseStatusRequest
{
    public string Description { get; }

    public CreateCaseStatusRequest(string description)
    {
        Description = description;
    }

    public CreateCaseStatusCommand ToApplicationRequest()
    {
        return new CreateCaseStatusCommand(Description);
    }
}