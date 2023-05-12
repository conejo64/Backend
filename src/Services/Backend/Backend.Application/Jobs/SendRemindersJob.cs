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
            var body = GetBody(typeRequirement!.Description, item.ReceptionDate.ToString(), originDocument!.Description, item.RequirementNumber, item.Description, brand!.Description,
                department!.Description, destinationUser!.FullName, item.TransferDate.ToString());
            //Notification
            if (destinationUser is not null)
            {
                _notificationService.SendEmailNotification(new EmailNotifictionModel()
                {
                    Subject = string.IsNullOrEmpty(item.Subject) ? "RECORDATORIO SECRETARIA" : item.Subject,
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
                   + "Tipo Requerimiento: " + descriptiontype + "<br/>"
                   + "Fecha de Recepción: " + receptionDate + "<br/>"
                   + "Origen del Documento: " + descriptionOrigin + "<br/>"
                   + "Nro. Documento: " + number + "<br/>"
                   + "Descripción: " + description + "<br/>"
                   + "Entidad: " + entidad + "<br/>"
                   + "Area Responsable: " + department + "<br/>"
                   + "Destinatario Responsable:" + user + "<br/>"
                   + "Fecha Límite: " + transferDate + "<br/>"
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
        return body!;
    }
}

