using Backend.Application.Commands.CaseStatusCommands;
using Backend.Domain.SeedWork;

namespace Backend.API.DTOs.Requests.CaseStatusRequests;

public class DeleteCaseStatusRequest
{
    public DeleteCaseStatusCommand ToApplicationRequest(Guid id)
    {
        return new DeleteCaseStatusCommand(id);
    }
}