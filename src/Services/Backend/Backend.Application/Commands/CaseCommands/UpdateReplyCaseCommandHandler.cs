using AutoMapper.Execution;
using Backend.Application.DTOs.Responses.CaseResponses;
using Backend.Application.Specifications.CaseStatusSpecs;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;
using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands;

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
    private readonly IRepository<CaseStatus> _caseStatusRepository;
    public UpdateReplyCaseCommandHandler(IRepository<CaseEntity> repository, IRepository<User> userRepository, INotificationService notificationService, 
        IRepository<DocumentEntity> documentRepository, IOpenKmService openKmService, IRepository<Brand> brandRepository,
        IRepository<OriginDocument> originRepository, IRepository<TypeRequirement> typeRepository,
        IRepository<Department> departmentRepository, IRepository<CaseStatus> caseStatusRepository)
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
        _caseStatusRepository = caseStatusRepository;
    }

    public async Task<EntityResponse<bool>> Handle(UpdateReplyCaseCommand command, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);
        var brand = await _brandRepository.GetByIdAsync(entity.BrandId, cancellationToken);
        var typeRequirement = await _typeRepository.GetByIdAsync(entity.TypeRequirementId, cancellationToken);
        var originDocument = await _originRepository.GetByIdAsync(entity.OriginDocumentId, cancellationToken);
        var department = await _departmentRepository.GetByIdAsync(entity.DepartmentId, cancellationToken);
        var statusSpec = new CaseStatusSpec("RESPONDIDO");
        var statusId = await _caseStatusRepository.GetBySpecAsync(statusSpec, cancellationToken);
        if (entity == null)
        {
            return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.CaseNotFound));
        }
        entity.ReplyDate = DateTime.Now;
        entity.Comments = entity.Comments + " / " + command.Comments;
        entity.CaseStage = StageEnum.Secretary;
        entity.CaseStatusId = statusId!.Id;
        var replyDate = DateTime.Now;
        var receptionDateShort = Convert.ToDateTime(entity.ReceptionDate);
        await _repository.UpdateAsync(entity, cancellationToken);
        var destinationUser = await _userRepository.GetByIdAsync(entity.UserOriginId, cancellationToken);
        var originUser = await _userRepository.GetByIdAsync(entity.UserId, cancellationToken);
        string body = new("<p><br/>"
                          + "A continuación se adjunta un detalle de la respuesta al caso :<br/><br/>"
                          + "<b>Tipo Requerimiento:</b> " + typeRequirement!.Description + "<br/>"
                          + "<b>Fecha de Recepción: </b>" + receptionDateShort.ToShortDateString() + "<br/>"
                          + "<b>Origen del Documento: </b>" + originDocument!.Description + "<br/>"
                          + "<b>Nro. Documento: </b>" + entity.DocumentNumber + "<br/>"
                          + "<b>Descripción: </b>" + entity.Description + "<br/>"
                          + "<b>Entidad: </b>" + brand!.Description + "<br/>"
                          + "<b>Area Responsable: </b>" + department!.Description + "<br/>"
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
                    Document64 = string.Empty,// documentSplit[1],
                    Document64Name = command.DocumentStringNames!.ElementAt(i),
                    ContextType = contentTypeSplit[1].Split(';')[0],

                };
                await _documentRepository.AddAsync(document, cancellationToken);
                byte[] bytes = Convert.FromBase64String(documentSplit[1]);
                var stream = new MemoryStream(bytes);
                var fileName = command.DocumentStringNames!.ElementAt(i);
                var path = $"Cases/{entity.DocumentNumber}";

                await SaveFile(stream, fileName, command.ContentRootPath!,path,  cancellationToken);
                document = new DocumentEntity();
            }
            await _documentRepository.SaveChangesAsync(cancellationToken);
            _openKmService.SendOpenKm(command.DocumentString, command.DocumentString);
        }
        return true;
    }
    
    #region Files
    public string GetSavePath(string fileName, string prefix, string contentRootPath)
    {
        var dir = $"{contentRootPath}/AppFiles";
        if (prefix != null)
            dir = Path.Combine(dir, prefix);

        return Path.Combine(dir, fileName);
    }

    private async Task SaveFile(Stream fileStream, string fileName, string contentRootPath, string prefix = default,
        CancellationToken cancellationToken = default)
    {
        var savePath = GetSavePath(fileName, prefix, contentRootPath);
        var dir = $"{contentRootPath}/AppFiles";
        if (prefix != null)
            dir = Path.Combine(dir, prefix);

        var exist = Directory.Exists(dir);
        if (!exist)
        {
            Directory.CreateDirectory(dir);
        }

        await using var stream = File.Create(savePath);
        await fileStream.CopyToAsync(stream, cancellationToken);
    }
    #endregion

}