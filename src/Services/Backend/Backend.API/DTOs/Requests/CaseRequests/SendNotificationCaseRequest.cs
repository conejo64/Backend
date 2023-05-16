using Backend.Application.Commands.CaseCommands;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class SendNotificationCaseRequest
    {
        //Screen Department
        public string? Message { get; set; }

        public SendNotificationCaseRequest(string? message)
        {
            Message = message;
        }

        public SendNotificationCaseCommand ToApplicationRequest(Guid id)
        {
            return new SendNotificationCaseCommand(id, Message);
        }
    }
}
