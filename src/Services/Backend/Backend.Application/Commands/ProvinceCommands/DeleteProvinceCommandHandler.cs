namespace Backend.Application.Commands.ProvinceCommands
{
    public class DeleteProvinceCommandHandler : IRequestHandler<DeleteProvinceCommand, EntityResponse<bool>>
    {
        private readonly IRepository<Province> _repository;

        public DeleteProvinceCommandHandler(IRepository<Province> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(DeleteProvinceCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
            }

            entity.Status = CatalogsStatus.Deleted;

            await _repository.UpdateAsync(entity, cancellationToken);

            return true;
        }

    }
}