namespace Backend.Application.Commands.BrandCommands
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, EntityResponse<bool>>
    {
        private readonly IRepository<Brand> _repository;

        public DeleteBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(DeleteBrandCommand command, CancellationToken cancellationToken)
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