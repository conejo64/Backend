using Backend.Application.DTOs.Responses.CaseResponses;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;
using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands
{
    public class UpdateReplyCaseCommandHandler : IRequestHandler<UpdateReplyCaseCommand, EntityResponse<bool>>
    {
        private readonly IRepository<CaseEntity> _repository;
        private readonly IRepository<User> _userRepository;
        private readonly INotificationService _notificationService;
        private readonly IRepository<DocumentEntity> _documentRepository;

        public UpdateReplyCaseCommandHandler(IRepository<CaseEntity> repository, IRepository<User> userRepository, INotificationService notificationService, IRepository<DocumentEntity> documentRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _notificationService = notificationService;
            _documentRepository = documentRepository;
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
            entity.CaseStage = StageEnum.Secretary;

            await _repository.UpdateAsync(entity, cancellationToken);
            var destinationUser = await _userRepository.GetByIdAsync(entity.UserOriginId, cancellationToken);
            var originUser = await _userRepository.GetByIdAsync(entity.UserId, cancellationToken);
            string body = new("<p><br/>"
                    + "A continuación se adjunta un detalle del caso:<br/><br/>"
                    + "Fecha de Contestación: " + command.ReplyDate + "<br/>"
                    + "Observaciones: " + command.Comments+ "<br/>"
                    + "<a href>Por favor haga click en el siguiente enlace</a>"
                    + "</p>");
            //Notificar a responsable
            if (destinationUser is not null)
            {
                _notificationService.SendEmailNotification(new EmailNotifictionModel()
                {
                    Subject = string.IsNullOrEmpty(entity.Subject) ? "NOTIFICACION RESPUESTA A SECRETARIA" : entity.Subject,
                    To = destinationUser.Email,
                    Cc = originUser!.Email,
                    Body = body
                });
            }
            for (int i = 0; i < command.DocumentString!.Count; i++)
            {
                var documentSplit = command.DocumentString.ElementAt(i).Split(',');
                var contentTypeSplit = documentSplit[0].Split(':');
                var document = new DocumentEntity
                {
                    CaseEntityId = entity.Id,
                    DocumentSource = DocumentSourceEnum.Reply,
                    Document64 = documentSplit[1],
                    Document64Name = command.DocumentStringNames!.ElementAt(i),
                    ContextType = contentTypeSplit[1].Split(';')[0],

                };
                await _documentRepository.AddAsync(document, cancellationToken);
                document = new DocumentEntity();
            }

            return true;
        }

    }
}
