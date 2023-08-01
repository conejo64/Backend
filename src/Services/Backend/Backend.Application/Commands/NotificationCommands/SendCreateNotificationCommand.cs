namespace Backend.Application.Commands.NotificationCommands;

public class SendCreateNotificationCommand : IRequest<EntityResponse<bool>>
{
    public Guid? CaseEntityId { get; set; }
    public string? ContentRootPath { get; set; }

    public SendCreateNotificationCommand(Guid? caseEntityId, string? contentRootPath)
    {
        CaseEntityId = caseEntityId;
        ContentRootPath = contentRootPath;
    }
}