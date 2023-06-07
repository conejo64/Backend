using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands;

public class UpdateReplyCaseCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; }
    //Screen Department
    public DateTime? ReplyDate { get; set; }
    public string? Comments { get; set; }
    public List<string>? DocumentString { get; set; }
    public List<string>? DocumentStringNames { get; set; }

    public UpdateReplyCaseCommand(Guid id, DateTime? replyDate, string? comments, List<string>? documentString, List<string>? documentStringNames)
    {
        Id = id;
        ReplyDate = replyDate;
        Comments = comments;
        DocumentString = documentString;
        DocumentStringNames = documentStringNames;
    }
}