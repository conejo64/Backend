using Backend.Application.Commands.CaseCommands;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class UpdateReplyCaseRequest
    {
        //Screen Department
        public DateTime? ReplyDate { get; set; }
        public string? Comments { get; set; }

        public UpdateReplyCaseRequest(DateTime? replyDate, string? comments)
        {
            ReplyDate = replyDate;
            Comments = comments;
        }

        public UpdateReplyCaseCommand ToApplicationRequest(Guid id)
        {
            return new UpdateReplyCaseCommand(id, ReplyDate, Comments);
        }
    }
}
