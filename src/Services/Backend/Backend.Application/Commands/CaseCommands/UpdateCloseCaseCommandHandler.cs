using Backend.Application.DTOs.Responses.CaseResponses;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;
using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands
{
    public class UpdateCloseCaseCommandHandler : IRequestHandler<UpdateCloseCaseCommand, EntityResponse<bool>>
    {
        private readonly IRepository<CaseEntity> _repository;
        private readonly IRepository<CaseStatus> _repositoryCaseStatus;
        private readonly INotificationService _notificationService;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<CaseStatusSecretary> _repositoryCaseStatusSecretary;
        public UpdateCloseCaseCommandHandler(IRepository<CaseEntity> repository, IRepository<CaseStatus> repositoryCaseStatus, INotificationService notificationService, IRepository<User> userRepository, IRepository<CaseStatusSecretary> repositoryCaseStatusSecretary)
        {
            _repository = repository;
            _repositoryCaseStatus = repositoryCaseStatus;
            _notificationService = notificationService;
            _userRepository = userRepository;
            _repositoryCaseStatusSecretary = repositoryCaseStatusSecretary;
        }

        public async Task<EntityResponse<bool>> Handle(UpdateCloseCaseCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.CaseNotFound));
            }

            entity.ResponseDate = command.ResponseDate;
            entity.CaseStatusId = command.CaseStatusId;
            entity.ObservationDepartment = entity.ObservationDepartment + " / " + command.ObservationDepartment;
            entity.CaseStatusSecretaryId = command.CaseStatusSecretaryId;
            entity.AcknowledgmentDate = command.AcknowledgmentDate;

            await _repository.UpdateAsync(entity, cancellationToken);
            var destinationUser = await _userRepository.GetByIdAsync(entity.UserId, cancellationToken);
            var origintionUser = await _userRepository.GetByIdAsync(entity.UserOriginId, cancellationToken);
            var caseStatus = await _repositoryCaseStatus.GetByIdAsync(entity.CaseStatusId, cancellationToken);
            var caseStatusSecretary = await _repositoryCaseStatusSecretary.GetByIdAsync(entity.CaseStatusSecretaryId, cancellationToken);
            string body = new string("<p>Se ha finalizado la tarea.<br/>"
                    + "A continuación se adjunta un detalle del caso cerrado:<br/><br/>"
                    + "Fecha Respuesta: " + command.ResponseDate + "<br/>"
                    + "Estado del Caso: " + caseStatus!.Description + "<br/>"
                    + "Comentarios Finales: " + command.ObservationDepartment! + "<br/>"
                    + "Revisión de Secretaria: " + caseStatusSecretary!.Description + "<br/>"
                    + "Fecha Acuse recibido: " + command.AcknowledgmentDate + "<br/>"
                    + "</p>");
            if (destinationUser is not null)
            {
                _notificationService.SendEmailNotification(new EmailNotifictionModel()
                {
                    Subject = string.IsNullOrEmpty(entity.Subject) ? "NOTIFICACION CIERRE DE REQUERIMIENTO SECRETARIA" : entity.Subject,
                    To = destinationUser.Email,
                    Cc = origintionUser!.Email,
                    Body = body
                });
            }
            return true;
        }

    }
}
