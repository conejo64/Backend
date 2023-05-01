using Backend.Application.Commands.ReminderCommands;

namespace Backend.API.DTOs.Requests.ReminderRequests;

public class UpdateReminderRequest
{
    public string Description { get; }

    public UpdateReminderRequest(string description)
    {
        Description = description;
    }

    public UpdateReminderCommand ToApplicationRequest(Guid id)
    {
        return new UpdateReminderCommand(id, Description);
    }
}