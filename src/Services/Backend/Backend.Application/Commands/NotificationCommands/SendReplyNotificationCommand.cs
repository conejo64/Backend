namespace Backend.Application.Commands.NotificationCommands;

public class SendReplyNotificationCommand : IRequest<EntityResponse<bool>>
{
    public Guid? CaseEntityId { get; set; }
    public string? ContentRootPath { get; set; }

    public SendReplyNotificationCommand(Guid? caseEntityId, string? contentRootPath)
    {
        CaseEntityId = caseEntityId;
        ContentRootPath = contentRootPath;
    }
}