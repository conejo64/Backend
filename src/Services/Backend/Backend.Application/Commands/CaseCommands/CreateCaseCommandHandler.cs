using Backend.Application.Specifications.CaseStatusSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands
{
    public class CreateCaseCommandHandler : IRequestHandler<CreateCaseCommand, EntityResponse<Guid>>
    {
        private readonly IRepository<CaseEntity> _repository;
        private readonly IRepository<CaseStatus> _repositoryCaseStatus;

        public CreateCaseCommandHandler(IRepository<CaseEntity> repository, IRepository<CaseStatus> repositoryCaseStatus)
        {
            _repository = repository;
            _repositoryCaseStatus = repositoryCaseStatus;
        }

        public async Task<EntityResponse<Guid>> Handle(CreateCaseCommand command, CancellationToken cancellationToken)
        {
            var statusSpec = new CaseStatusSpec("ABIERTO");
            var statusId = await _repositoryCaseStatus.GetBySpecAsync(statusSpec, cancellationToken);
            var entity = new CaseEntity(command.RequirementNumber, command.ReceptionDate, command.OriginDocumentId, command.PhysicallyReceived, command.DigitallyReceived, command.DocumentNumber,
                                        command.SbsNumber, command.JudgmentNumber, command.IssueDate, command.Description, command.BrandId, command.DepartmentId, command.UserId, command.TypeRequirementId,
                                        command.Notification, command.Subject, command.TransferDate, command.Deadline, command.ProvinceId, command.DueDate, command.ReminderId, command.ReplyDate, command.Comments,
                                        command.ResponseDate, statusId!.Id, command.ObservationDepartment, command.CaseStatusSecretaryId, command.AcknowledgmentDate, command.ExtensionRequestDate, command.NewExtensionRequestDate, 
                                        command.ObservationExtension);
            await _repository.AddAsync(entity, cancellationToken);

            return EntityResponse.Success(entity.Id);
        }
    }
    
}
