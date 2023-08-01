using Backend.Application.Commands.NotificationCommands;

namespace Backend.API.DTOs.Requests.NotificationRequests;

public class CreateNotificationRequest
{
    public SendCreateNotificationCommand ToApplicationRequest(Guid caseEntityId, string contentRootPath)
    {
        return new SendCreateNotificationCommand(caseEntityId, contentRootPath);
    }
}