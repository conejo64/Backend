using Backend.Application.Specifications.CaseStatusSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;

namespace Backend.Application.Commands.CaseCommands
{
    public class CreateCaseCommandHandler : IRequestHandler<CreateCaseCommand, EntityResponse<Guid>>
    {
        private readonly IRepository<CaseEntity> _repository;
        private readonly IRepository<CaseStatus> _repositoryCaseStatus;
        private readonly INotificationService _notificationService;
        private readonly IRepository<User> _userRepository;

        public CreateCaseCommandHandler(IRepository<CaseEntity> repository, IRepository<CaseStatus> repositoryCaseStatus,
            INotificationService notificationService, IRepository<User> userRepository)
        {
            _repository = repository;
            _repositoryCaseStatus = repositoryCaseStatus;
            _notificationService = notificationService;
            _userRepository = userRepository;
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
            
            //Notificar a responsable
            var destinationUser = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);
            if (destinationUser is not null)
            {
                _notificationService.SendEmailNotification(new EmailNotifictionModel()
                {
                    Subject = command.Subject,
                    To = destinationUser.Email,
                    Body = "Notificación de caso"
                });
    
            }
            
            return EntityResponse.Success(entity.Id);
        }
    }
    
}
