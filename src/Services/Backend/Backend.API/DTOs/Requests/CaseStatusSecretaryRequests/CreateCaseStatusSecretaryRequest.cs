using Backend.Application.Commands.CaseStatusSecretaryCommands;

namespace Backend.API.DTOs.Requests.CaseStatusSecretaryRequests;

public class CreateCaseStatusSecretaryRequest
{
    public string Description { get; }

    public CreateCaseStatusSecretaryRequest(string description)
    {
        Description = description;
    }

    public CreateCaseStatusSecretaryCommand ToApplicationRequest()
    {
        return new CreateCaseStatusSecretaryCommand(Description);
    }
}