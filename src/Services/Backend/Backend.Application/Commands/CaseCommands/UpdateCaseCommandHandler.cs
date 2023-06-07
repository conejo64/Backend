using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands;

public class UpdateCaseCommandHandler : IRequestHandler<UpdateCaseCommand, EntityResponse<bool>>
{
    private readonly IRepository<CaseEntity> _repository;

    public UpdateCaseCommandHandler(IRepository<CaseEntity> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<bool>> Handle(UpdateCaseCommand command, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (entity == null)
        {
            return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.CaseNotFound));
        }

        entity.AcknowledgmentDate = command.AcknowledgmentDate;
        entity.BrandId = command.BrandId;
        entity.CaseStatusId = command.CaseStatusId;
        entity.CaseStatusSecretaryId = command.CaseStatusSecretaryId;
        entity.Comments = command.Comments;
        entity.Deadline = command.Deadline;
        entity.DepartmentId = command.DepartmentId;
        entity.Description = command.Description;
        entity.DigitallyReceived = command.DigitallyReceived;
        entity.DocumentNumber = command.DocumentNumber;
        entity.DueDate = command.DueDate;
        entity.ExtensionRequestDate = command.ExtensionRequestDate;
        entity.IssueDate = command.IssueDate;
        entity.JudgmentNumber = command.JudgmentNumber;
        entity.JudgmentNumber = command.JudgmentNumber;
        entity.NewExtensionRequestDate = command.NewExtensionRequestDate;
        entity.Notification = command.Notification;
        entity.ObservationDepartment = command.ObservationDepartment;
        entity.ObservationExtension = command.ObservationExtension;
        entity.OriginDocumentId = command.OriginDocumentId;
        entity.PhysicallyReceived = command.PhysicallyReceived;
        entity.ProvinceId = command.ProvinceId;
        entity.ReceptionDate = command.ReceptionDate;
        entity.ReminderId = command.ReminderId;
        entity.ReplyDate = command.ReplyDate;
        entity.RequirementNumber = command.RequirementNumber;
        entity.ResponseDate = command.ResponseDate;
        entity.SbsNumber = command.SbsNumber;
        entity.Subject = command.Subject;
        entity.TransferDate = command.TransferDate;
        entity.TypeRequirementId = command.TypeRequirementId;
        entity.UserId = command.UserId;
        await _repository.UpdateAsync(entity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return true;
    }

}