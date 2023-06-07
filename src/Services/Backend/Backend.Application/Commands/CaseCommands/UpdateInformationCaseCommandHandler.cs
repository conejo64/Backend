using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;
using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands;

public class UpdateInformationCaseCommandHandler : IRequestHandler<UpdateInformationCaseCommand, EntityResponse<bool>>
{
    private readonly IRepository<CaseEntity> _repository;
    private readonly IRepository<User> _userRepository;
    private readonly INotificationService _notificationService;

    public UpdateInformationCaseCommandHandler(IRepository<CaseEntity> repository, INotificationService notificationService, IRepository<User> userRepository)
    {
        _repository = repository;
        _notificationService = notificationService;
        _userRepository = userRepository;
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
        var destinationUser = await _userRepository.GetByIdAsync(entity.UserOriginId, cancellationToken);
        var originUser = await _userRepository.GetByIdAsync(entity.UserId, cancellationToken);
        string body = new("<p><br/>"
                          + "A continuación se adjunta un detalle del caso solicitando mas información:<br/><br/>"
                          + "<b>Fecha de Contestación: </b>" + DateTime.Now.ToString("dd/MM/yyyy") + "<br/>"
                          + "<b>Observaciones: </b>" + command.Comments + "<br/>"
                          + "<b>Nro. Documento: </b>" + entity.DocumentNumber + "<br/>"
                          + "<b>Descripción: </b>" + entity.Description + "<br/>"
                          + "<a href=https://openkmapp/workflow/#/auth/login>Por favor haga click en el siguiente enlace</a>"
                          + "<br />"
                          + "<br />"
                          + "<br />"
                          + "<b>Atentamente" + "<br/>"
                          + "<b>Secretaria General</b>"
                          + "<br />"
                          + "<br />"
                          + "<b>PD: Cualquier duda o inquietud comunicarse con Lorena Moreira (mmoreira@dinersclub.com.ec)</b>"
                          + "</p>"); ;
        //Notificar a responsable
        if (destinationUser is not null)
        {
            _notificationService.SendEmailNotification(new EmailNotifictionModel()
            {
                Subject = string.IsNullOrEmpty(entity.Subject) ? "NOTIFICACION SOLICITUD INFORMACION" : entity.Subject,
                To = destinationUser.Email,
                Cc = originUser!.Email,
                Body = body
            });
        }
        return true;
    }

}