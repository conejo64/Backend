namespace Backend.Application.Commands.ReminderCommands
{
    public class DeleteReminderCommandHandler : IRequestHandler<DeleteReminderCommand, EntityResponse<bool>>
    {
        private readonly IRepository<Reminder> _repository;

        public DeleteReminderCommandHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(DeleteReminderCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.RemainderNotFound));
            }

            entity.Status = CatalogsStatus.Deleted;

            await _repository.UpdateAsync(entity, cancellationToken);

            return true;
        }

    }
}