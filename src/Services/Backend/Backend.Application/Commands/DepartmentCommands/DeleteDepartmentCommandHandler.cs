namespace Backend.Application.Commands.DepartmentCommands;

public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, EntityResponse<bool>>
{
    private readonly IRepository<Department> _repository;

    public DeleteDepartmentCommandHandler(IRepository<Department> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<bool>> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (entity == null)
        {
            return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.DepartmentNotFound));
        }

        entity.Status = CatalogsStatus.Deleted;

        await _repository.UpdateAsync(entity, cancellationToken);

        return true;
    }

}