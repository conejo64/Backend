using AutoMapper.Execution;
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
        private readonly IOpenKmService _openKmService;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IRepository<TypeRequirement> _typeRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<OriginDocument> _originRepository;
        public UpdateReplyCaseCommandHandler(IRepository<CaseEntity> repository, IRepository<User> userRepository, INotificationService notificationService, 
            IRepository<DocumentEntity> documentRepository, IOpenKmService openKmService, IRepository<Brand> brandRepository,
            IRepository<OriginDocument> originRepository, IRepository<TypeRequirement> typeRepository,
            IRepository<Department> departmentRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _notificationService = notificationService;
            _documentRepository = documentRepository;
            _openKmService = openKmService;
            _brandRepository = brandRepository;
            _originRepository = originRepository;
            _typeRepository = typeRepository;
            _departmentRepository = departmentRepository;
            _originRepository = originRepository;
        }

        public async Task<EntityResponse<bool>> Handle(UpdateReplyCaseCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);
            var brand = await _brandRepository.GetByIdAsync(entity.BrandId, cancellationToken);
            var typeRequirement = await _typeRepository.GetByIdAsync(entity.TypeRequirementId, cancellationToken);
            var originDocument = await _originRepository.GetByIdAsync(entity.OriginDocumentId, cancellationToken);
            var department = await _departmentRepository.GetByIdAsync(entity.DepartmentId, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.CaseNotFound));
            }

            entity.ReplyDate = DateTime.Now;
            entity.Comments = entity.Comments + " / " + command.Comments;
            entity.CaseStage = StageEnum.Secretary;
            var replyDate = DateTime.Now;
            await _repository.UpdateAsync(entity, cancellationToken);
            var destinationUser = await _userRepository.GetByIdAsync(entity.UserOriginId, cancellationToken);
            var originUser = await _userRepository.GetByIdAsync(entity.UserId, cancellationToken);
            string body = new("<p><br/>"
                    + "A continuación se adjunta un detalle de la respuesta al caso :<br/><br/>"
                    + "<b>Tipo Requerimiento:</b> " + typeRequirement!.Description + "<br/>"
                    + "<b>Fecha de Recepción: </b>" + entity.ReceptionDate + "<br/>"
                    + "<b>Origen del Documento: </b>" + originDocument!.Description + "<br/>"
                    + "<b>Nro. Documento: </b>" + entity.DocumentNumber + "<br/>"
                    + "<b>Descripción: </b>" + entity.Description + "<br/>"
                    + "<b>Entidad: </b>" + brand!.Description + "<br/>"
                    + "<b>Area Responsable: </b>" + department + "<br/>"
                    + "<b>Nro.Documento: </ b > " + entity.DocumentNumber + " < br /> "
                    + "<b>Fecha de Contestación: </b>" + replyDate.ToShortDateString() + "<br/>"
                    + "<b>Observaciones: </b>" + command.Comments+ "<br/>"
                    + "<a href=https://openkmapp/workflow/#/auth/login>Por favor haga click en el siguiente enlace</a>"
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
            if (command.DocumentString != null && command.DocumentStringNames != null)
            {
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
                await _documentRepository.SaveChangesAsync(cancellationToken);
                _openKmService.SendOpenKm(command.DocumentString, command.DocumentString);
            }
            return true;
        }

    }
}
