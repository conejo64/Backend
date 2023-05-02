using Backend.Application.Commands.ProfileCommands;
using Backend.Application.Specifications.ProfileSpecs;

namespace Backend.Application.Commands.CaseStatusCommands
{
    public class UpdateCaseStatusCommandHandler : IRequestHandler<UpdateCaseStatusCommand, EntityResponse<bool>>
    {
        private readonly IRepository<CaseStatus> _repository;

        public UpdateCaseStatusCommandHandler(IRepository<CaseStatus> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(UpdateCaseStatusCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.CaseStausNotFound));
            }

            entity.Description = command.Description;

            await _repository.UpdateAsync(entity, cancellationToken);

            return true;
        }

    }
}