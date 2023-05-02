namespace Backend.Application.Commands.CaseStatusSecretaryCommands
{
    public class DeleteCaseStatusSecretaryCommandHandler : IRequestHandler<DeleteCaseStatusSecretaryCommand, EntityResponse<bool>>
    {
        private readonly IRepository<CaseStatusSecretary> _repository;

        public DeleteCaseStatusSecretaryCommandHandler(IRepository<CaseStatusSecretary> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(DeleteCaseStatusSecretaryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.CaseStatusSecretayNotFound));
            }

            entity.Status = CatalogsStatus.Deleted;

            await _repository.UpdateAsync(entity, cancellationToken);

            return true;
        }

    }
}