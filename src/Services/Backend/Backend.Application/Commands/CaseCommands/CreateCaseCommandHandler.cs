using Backend.Application.Specifications.CaseStatusSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;
using Backend.Domain.Entities;
using System.Security.Policy;

namespace Backend.Application.Commands.CaseCommands
{
    public class CreateCaseCommandHandler : IRequestHandler<CreateCaseCommand, EntityResponse<Guid>>
    {
        private readonly IRepository<CaseEntity> _repository;
        private readonly IRepository<CaseStatus> _repositoryCaseStatus;
        private readonly INotificationService _notificationService;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<OriginDocument> _originRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IRepository<TypeRequirement> _typeRepository;
        private readonly IRepository<Department> _departmentRepository;

        public CreateCaseCommandHandler(IRepository<CaseEntity> repository, IRepository<CaseStatus> repositoryCaseStatus,
            INotificationService notificationService, IRepository<User> userRepository, IRepository<Brand> brandRepository, IRepository<OriginDocument> originRepository, 
            IRepository<TypeRequirement> typeRepository, IRepository<Department> departmentRepository)
        {
            _repository = repository;
            _repositoryCaseStatus = repositoryCaseStatus;
            _notificationService = notificationService;
            _userRepository = userRepository;
            _brandRepository = brandRepository;
            _originRepository = originRepository;
            _typeRepository = typeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<EntityResponse<Guid>> Handle(CreateCaseCommand command, CancellationToken cancellationToken)
        {
            var statusSpec = new CaseStatusSpec("ABIERTO");
            var statusId = await _repositoryCaseStatus.GetBySpecAsync(statusSpec, cancellationToken);
            var entity = new CaseEntity(command.RequirementNumber, DateTime.Now, command.OriginDocumentId, command.PhysicallyReceived, command.DigitallyReceived, command.DocumentNumber,
                                        command.SbsNumber, command.JudgmentNumber, command.IssueDate, command.Description, command.BrandId, command.DepartmentId, command.UserId, command.TypeRequirementId,
                                        command.Notification, command.Subject, command.TransferDate, command.Deadline, command.ProvinceId, command.DueDate, command.ReminderId, command.ReplyDate, command.Comments,
                                        command.ResponseDate, statusId!.Id, command.ObservationDepartment, command.CaseStatusSecretaryId, command.AcknowledgmentDate, command.ExtensionRequestDate, command.NewExtensionRequestDate, 
                                        command.ObservationExtension);
            await _repository.AddAsync(entity, cancellationToken);
            
            //Notificar a responsable
            var destinationUser = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);
            var brand = await _brandRepository.GetByIdAsync(command.BrandId, cancellationToken);
            var typeRequirement = await _typeRepository.GetByIdAsync(command.TypeRequirementId, cancellationToken);
            var originDocument = await _originRepository.GetByIdAsync(command.OriginDocumentId, cancellationToken);
            var department = await _departmentRepository.GetByIdAsync(command.DepartmentId, cancellationToken);
            var body = "<p><br/>"
                    + "A continuación se adjunta un detalle del caso:<br/><br/>"
                    + "Tipo Requerimiento: " + typeRequirement!.Description + "<br/>"
                    + "Fecha de Recepción: " + command.ReceptionDate + "<br/>"
                    + "Origen del Documento: " + originDocument!.Description + "<br/>"
                    + "Nro. Documento: " + command.RequirementNumber + "<br/>"
                    + "Descripción: " + command.Description + "<br/>"
                    + "Entidad: " + brand!.Description + "<br/>"
                    + "Area Responsable: " + department!.Description + "<br/>"
                    + "Destinatario Responsable:" + destinationUser!.FullName + "<br/>"
                    + "Fecha Límite: " + command.TransferDate+ "<br/>"
                    + "<a href=" + ">Por favor haga click en el siguiente enlace</a>"
                    + "<br />"
                    + "<br />"
                    + "<br />"
                    + "Atentamente" + "<br/>"
                    + "Secretaria General"
                    + "<br />"
                    + "<br />"
                    + "PD: Cualquier duda o inquietud comunicarse con Lorena Moreira (mmoreira@dinersclub.com.ec)"
                    + "</p>";
            if (destinationUser is not null)
            {
                _notificationService.SendEmailNotification(new EmailNotifictionModel()
                {
                    Subject = string.IsNullOrEmpty(command.Subject) ? "NOTIFICACION SECRETARIA" : command.Subject,
                    To = destinationUser.Email,
                    Body = body
                });
    
            }
            
            return EntityResponse.Success(entity.Id);
        }
    }
    
}
