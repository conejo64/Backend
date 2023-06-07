namespace Backend.Application.Commands.ReminderCommands;

public class DeleteReminderCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; }

    public DeleteReminderCommand(Guid id)
    {
        Id = id;
    }
}