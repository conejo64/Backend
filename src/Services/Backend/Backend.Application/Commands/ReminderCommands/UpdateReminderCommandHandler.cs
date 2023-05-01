namespace Backend.Application.Commands.ReminderCommands
{
    public class UpdateReminderCommandHandler : IRequestHandler<UpdateReminderCommand, EntityResponse<bool>>
    {
        private readonly IRepository<Reminder> _repository;

        public UpdateReminderCommandHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(UpdateReminderCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
            }

            entity.Description = command.Description;

            await _repository.UpdateAsync(entity, cancellationToken);

            return true;
        }

    }
}