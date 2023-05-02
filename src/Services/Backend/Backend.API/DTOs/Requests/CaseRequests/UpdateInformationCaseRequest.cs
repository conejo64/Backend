using Backend.Application.Commands.CaseCommands;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class UpdateInformationCaseRequest
    {
        //Screen more Information
        public string? Comments { get; set; }

        public UpdateInformationCaseRequest(string? comments)
        {
            Comments = comments;
        }

        public UpdateInformationCaseCommand ToApplicationRequest(Guid id)
        {
            return new UpdateInformationCaseCommand(id, Comments);
        }
    }
}
