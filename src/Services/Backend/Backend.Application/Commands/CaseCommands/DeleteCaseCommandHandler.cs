using Backend.Application.Commands.BrandCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands
{
    public class DeleteCaseCommandHandler : IRequestHandler<DeleteCaseCommand, EntityResponse<bool>>
    {
        private readonly IRepository<CaseEntity> _repository;

        public DeleteCaseCommandHandler(IRepository<CaseEntity> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(DeleteCaseCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
            }

            entity.Status = CatalogsStatus.Deleted;

            await _repository.UpdateAsync(entity, cancellationToken);

            return true;
        }

    }
}
