namespace Backend.Application.Commands.NotificationCommands;

public class SendCloseNotificationCommand : IRequest<EntityResponse<bool>>
{
    public Guid? CaseEntityId { get; set; }
    public string? ContentRootPath { get; set; }

    public SendCloseNotificationCommand(Guid? caseEntityId, string? contentRootPath)
    {
        CaseEntityId = caseEntityId;
        ContentRootPath = contentRootPath;
    }
}