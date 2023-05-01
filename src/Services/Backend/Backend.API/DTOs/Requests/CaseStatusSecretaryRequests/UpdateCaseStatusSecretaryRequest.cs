using Backend.Application.Commands.CaseStatusSecretaryCommands;

namespace Backend.API.DTOs.Requests.CaseStatusSecretaryRequests;

public class UpdateCaseStatusSecretaryRequest
{
    public string Description { get; }

    public UpdateCaseStatusSecretaryRequest(string description)
    {
        Description = description;
    }

    public UpdateCaseStatusSecretaryCommand ToApplicationRequest(Guid id)
    {
        return new UpdateCaseStatusSecretaryCommand(id, Description);
    }
}