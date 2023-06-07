using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands;

public class SendNotificationCaseCommand : IRequest<EntityResponse<bool>>
{
    public Guid CaseId { get; }
    //Screen Department
    public string? Message { get; set; }

    public SendNotificationCaseCommand(Guid caseId, string? message)
    {
        CaseId = caseId;
        Message = message;
    }
}