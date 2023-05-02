using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands
{
    public class UpdateExtensionCaseCommandHandler : IRequestHandler<UpdateExtensionCaseCommand, EntityResponse<bool>>
    {
        private readonly IRepository<CaseEntity> _repository;

    public UpdateExtensionCaseCommandHandler(IRepository<CaseEntity> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<bool>> Handle(UpdateExtensionCaseCommand command, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (entity == null)
        {
            return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.CaseNotFound));
        }

        entity.ExtensionRequestDate = command.ExtensionRequestDate;
        entity.NewExtensionRequestDate = command.NewExtensionRequestDate;
        entity.ObservationExtension = command.ObservationExtension;
        entity.Deadline = command.NewExtensionRequestDate;
        
        await _repository.UpdateAsync(entity, cancellationToken);

        return true;
    }

}
}
