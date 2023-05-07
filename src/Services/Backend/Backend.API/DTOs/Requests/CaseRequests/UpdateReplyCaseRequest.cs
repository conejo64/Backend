using Backend.Application.Commands.CaseCommands;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class UpdateReplyCaseRequest
    {
        //Screen Department
        public DateTime? ReplyDate { get; set; }
        public string? Comments { get; set; }
        public List<string>? DocumentString { get; set; }
        public List<string>? DocumentStringNames { get; set; }

        public UpdateReplyCaseRequest(DateTime? replyDate, string? comments, List<string>? documentString, List<string>? documentStringNames)
        {
            ReplyDate = replyDate;
            Comments = comments;
            DocumentString = documentString;
            DocumentStringNames = documentStringNames;
        }

        public UpdateReplyCaseCommand ToApplicationRequest(Guid id)
        {
            return new UpdateReplyCaseCommand(id, ReplyDate, Comments, DocumentString, DocumentStringNames);
        }
    }
}
