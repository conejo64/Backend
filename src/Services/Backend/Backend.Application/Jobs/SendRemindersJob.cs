using Backend.Application.Queries.CaseQueries;
using Backend.Application.Specifications.CaseSpecs;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;
using Quartz;

namespace Backend.Application.Jobs;

[DisallowConcurrentExecution]
public class SendRemindersJob : IJob
{
    #region Constructor && Properties

    private readonly IRepository<CaseEntity> _repository;
    private readonly INotificationService _notificationService;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<OriginDocument> _originRepository;
    private readonly IRepository<Brand> _brandRepository;
    private readonly IRepository<TypeRequirement> _typeRepository;
    private readonly IRepository<Department> _departmentRepository;
    private readonly IRepository<Reminder> _reminderRepository;

    public SendRemindersJob(IRepository<CaseEntity> repository, INotificationService notificationService,
        IRepository<User> userRepository, IRepository<OriginDocument> originRepository,
        IRepository<Brand> brandRepository, IRepository<TypeRequirement> typeRepository, 
        IRepository<Department> departmentRepository, IRepository<Reminder> reminderRepository)
    {
        _repository = repository;
        _notificationService = notificationService;
        _userRepository = userRepository;
        _originRepository = originRepository;
        _brandRepository = brandRepository;
        _typeRepository = typeRepository;
        _departmentRepository = departmentRepository;
        _reminderRepository = reminderRepository;
    }

    #endregion

    public async Task Execute(IJobExecutionContext context)
    {
        var spec = new CaseReminderSpec();
        var cases = await _repository.ListAsync(spec, context.CancellationToken);

        foreach (var item in cases)
        {
            var destinationUser = await _userRepository.GetByIdAsync(item.UserId, context.CancellationToken);
            var brand = await _brandRepository.GetByIdAsync(item.BrandId, context.CancellationToken);
            var typeRequirement = await _typeRepository.GetByIdAsync(item.TypeRequirementId, context.CancellationToken);
            var originDocument = await _originRepository.GetByIdAsync(item.OriginDocumentId, context.CancellationToken);
            var department = await _departmentRepository.GetByIdAsync(item.DepartmentId, context.CancellationToken);
            var body = GetBody(typeRequirement!.Description, item.ReceptionDate.ToString(), originDocument!.Description, item.DocumentNumber, item.Description, brand!.Description,
                department!.Description, destinationUser!.FullName, item.TransferDate.ToString());
            //Notification
            if (destinationUser is not null)
            {
                _notificationService.SendEmailNotification(new EmailNotifictionModel()
                {
                    Subject = string.IsNullOrEmpty(item.Subject) ? "RECORDATORIO SECRETARIA" : item.Subject + " - RECORDATORIO",
                    To = destinationUser.Email,
                    Body = body
                });
            }
            var reminderSelect = await _reminderRepository.GetByIdAsync(item.ReminderId!, context.CancellationToken);
            var reminderDate = DateTime.Now;
            if (reminderSelect != null)
            {
                var hour = Int32.Parse(reminderSelect.Description!);
                item.ReminderDate = reminderDate.AddHours(hour);
            }

            await _repository.SaveChangesAsync();
        }
    }
    
    public static string GetBody (string? descriptiontype, string? receptionDate, string? descriptionOrigin, string? number, string? description, string? entidad, 
        string? department, string? user, string? transferDate)
    {
        var body = "<p><br/>"
                   + "A continuación se adjunta un detalle del caso:<br/><br/>"
                   + "<b>Tipo Requerimiento:</b> " + descriptiontype + "<br/>"
                   + "<b>Fecha de Recepción: </b>" + receptionDate + "<br/>"
                   + "<b>Origen del Documento: </b>" + descriptionOrigin + "<br/>"
                   + "<b>Nro. Documento: </b>" + number + "<br/>"
                   + "<b>Descripción: </b>" + description + "<br/>"
                   + "<b>Entidad: </b>" + entidad + "<br/>"
                   + "<b>Area Responsable: </b>" + department + "<br/>"
                   + "<b>Destinatario Responsable: </b>" + user + "<br/>"
                   + "<b>Fecha Límite: </b>" + transferDate + "<br/>"
                   + "<a href=https://openkmapp/workflow/" + ">Por favor haga click en el siguiente enlace</a>"
                   + "<br />"
                   + "<br />"
                   + "<br />"
                   + "<b>Atentamente" + "<br/>"
                   + "<b>Secretaria General</b>"
                   + "<br />"
                   + "<br />"
                   + "<b>PD: Cualquier duda o inquietud comunicarse con Lorena Moreira (mmoreira@dinersclub.com.ec)</b>"
                   + "</p>";
        return body!;
    }
}

