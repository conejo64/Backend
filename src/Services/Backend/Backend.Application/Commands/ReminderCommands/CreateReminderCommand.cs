namespace Backend.Application.Commands.ReminderCommands;

public class CreateReminderCommand : IRequest<EntityResponse<Guid>>
{
    public string Description { get; }

    public CreateReminderCommand(string description)
    {
        Description = description;
    }
}