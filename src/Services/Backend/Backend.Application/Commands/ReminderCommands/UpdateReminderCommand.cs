namespace Backend.Application.Commands.ReminderCommands
{
    public class UpdateReminderCommand : IRequest<EntityResponse<bool>>
    {
        public Guid Id { get; }
        public string Description { get; }

        public UpdateReminderCommand(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}