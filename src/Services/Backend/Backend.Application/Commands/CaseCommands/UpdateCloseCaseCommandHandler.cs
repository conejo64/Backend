using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands
{
    public class UpdateCloseCaseCommandHandler : IRequestHandler<UpdateCloseCaseCommand, EntityResponse<bool>>
    {
        private readonly IRepository<CaseEntity> _repository;

    public UpdateCloseCaseCommandHandler(IRepository<CaseEntity> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<bool>> Handle(UpdateCloseCaseCommand command, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (entity == null)
        {
            return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.CaseNotFound));
        }

        entity.ResponseDate= command.ResponseDate;
            entity.CaseStatusId = command.CaseStatusId;
            entity.ObservationDepartment = entity.ObservationDepartment + " / " + command.ObservationDepartment;
            entity.CaseStatusSecretaryId = command.CaseStatusSecretaryId;
            entity.AcknowledgmentDate = command.AcknowledgmentDate;
        
        await _repository.UpdateAsync(entity, cancellationToken);

        return true;
    }

}
}
