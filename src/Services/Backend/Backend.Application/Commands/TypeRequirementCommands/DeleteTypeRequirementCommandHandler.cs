namespace Backend.Application.Commands.TypeRequirementCommands
{
    public class DeleteTypeRequirementCommandHandler : IRequestHandler<DeleteTypeRequirementCommand, EntityResponse<bool>>
    {
        private readonly IRepository<TypeRequirement> _repository;

        public DeleteTypeRequirementCommandHandler(IRepository<TypeRequirement> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(DeleteTypeRequirementCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.TypeRequireNotFound));
            }

            entity.Status = CatalogsStatus.Deleted;

            await _repository.UpdateAsync(entity, cancellationToken);

            return true;
        }

    }
}