using Backend.Application.Commands.CaseStatusSecretaryCommands;
using Backend.Domain.SeedWork;

namespace Backend.API.DTOs.Requests.CaseStatusSecretaryRequests;

public class DeleteCaseStatusSecretaryRequest
{
    public DeleteCaseStatusSecretaryCommand ToApplicationRequest(Guid id)
    {
        return new DeleteCaseStatusSecretaryCommand(id);
    }
}