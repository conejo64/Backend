using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands
{
    public class UpdateReplyCaseCommandHandler : IRequestHandler<UpdateReplyCaseCommand, EntityResponse<bool>>
    {
        private readonly IRepository<CaseEntity> _repository;

        public UpdateReplyCaseCommandHandler(IRepository<CaseEntity> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(UpdateReplyCaseCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.CaseNotFound));
            }

            entity.ReplyDate = command.ReplyDate;
            entity.Comments = entity.Comments + " / " + command.Comments;

            await _repository.UpdateAsync(entity, cancellationToken);

            return true;
        }

    }
}
