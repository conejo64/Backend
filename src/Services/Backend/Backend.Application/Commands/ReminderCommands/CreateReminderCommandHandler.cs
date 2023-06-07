namespace Backend.Application.Commands.ReminderCommands;

public class CreateReminderCommandHandler : IRequestHandler<CreateReminderCommand, EntityResponse<Guid>>
{
    private readonly IRepository<Reminder> _repository;

    public CreateReminderCommandHandler(IRepository<Reminder> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<Guid>> Handle(CreateReminderCommand command, CancellationToken cancellationToken)
    {
        var entity = new Reminder(command.Description);
        await _repository.AddAsync(entity, cancellationToken);
            
        return EntityResponse.Success(entity.Id);
    }
}