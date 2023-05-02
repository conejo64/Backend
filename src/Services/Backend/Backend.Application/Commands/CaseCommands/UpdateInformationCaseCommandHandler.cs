using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands
{
    public class UpdateInformationCaseCommandHandler : IRequestHandler<UpdateInformationCaseCommand, EntityResponse<bool>>
    {
        private readonly IRepository<CaseEntity> _repository;

        public UpdateInformationCaseCommandHandler(IRepository<CaseEntity> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(UpdateInformationCaseCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.CaseNotFound));
            }
            entity.Comments = entity.Comments + " / " + command.Comments;
            await _repository.UpdateAsync(entity, cancellationToken);
            return true;
        }

    }
}
