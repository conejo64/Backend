
namespace Backend.Application.Commands.ProvinceCommands
{
    public class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceCommand, EntityResponse<bool>>
    {
        private readonly IRepository<Province> _repository;

        public UpdateProvinceCommandHandler(IRepository<Province> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(UpdateProvinceCommand command, CancellationToken cancellationToken)
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