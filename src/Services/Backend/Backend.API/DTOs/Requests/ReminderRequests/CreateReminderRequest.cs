using Backend.Application.Commands.ReminderCommands;

namespace Backend.API.DTOs.Requests.ReminderRequests;

public class CreateReminderRequest
{
    public string Description { get; }

    public CreateReminderRequest(string description)
    {
        Description = description;
    }

    public CreateReminderCommand ToApplicationRequest()
    {
        return new CreateReminderCommand(Description);
    }
}