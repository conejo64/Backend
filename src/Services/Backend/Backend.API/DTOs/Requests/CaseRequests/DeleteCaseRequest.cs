using Backend.Application.Commands.CaseCommands;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class DeleteCaseRequest
    {
        public DeleteCaseCommand ToApplicationRequest(Guid id)
        {
            return new DeleteCaseCommand(id);
        }
    }
}
