using Backend.Application.Commands.ReminderCommands;
using Backend.Domain.SeedWork;

namespace Backend.API.DTOs.Requests.ReminderRequests;

public class DeleteReminderRequest
{
    public DeleteReminderCommand ToApplicationRequest(Guid id)
    {
        return new DeleteReminderCommand(id);
    }
}