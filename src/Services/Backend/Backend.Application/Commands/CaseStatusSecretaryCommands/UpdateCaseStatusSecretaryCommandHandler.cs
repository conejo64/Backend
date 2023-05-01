using Backend.Application.Commands.ProfileCommands;
using Backend.Application.Specifications.ProfileSpecs;

namespace Backend.Application.Commands.CaseStatusSecretaryCommands
{
    public class UpdateCaseStatusSecretaryCommandHandler : IRequestHandler<UpdateCaseStatusSecretaryCommand, EntityResponse<bool>>
    {
        private readonly IRepository<CaseStatusSecretary> _repository;

        public UpdateCaseStatusSecretaryCommandHandler(IRepository<CaseStatusSecretary> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(UpdateCaseStatusSecretaryCommand command, CancellationToken cancellationToken)
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