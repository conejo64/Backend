using Backend.Application.Commands.ProfileCommands;
using Backend.Application.Specifications.ProfileSpecs;

namespace Backend.Application.Commands.TypeRequirementCommands
{
    public class UpdateTypeRequirementCommandHandler : IRequestHandler<UpdateTypeRequirementCommand, EntityResponse<bool>>
    {
        private readonly IRepository<TypeRequirement> _repository;

        public UpdateTypeRequirementCommandHandler(IRepository<TypeRequirement> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(UpdateTypeRequirementCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.TypeRequireNotFound));
            }

            entity.Description = command.Description;

            await _repository.UpdateAsync(entity, cancellationToken);

            return true;
        }

    }
}