namespace Backend.Application.Commands.DepartmentCommands
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, EntityResponse<bool>>
    {
        private readonly IRepository<Department> _repository;

        public UpdateDepartmentCommandHandler(IRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
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