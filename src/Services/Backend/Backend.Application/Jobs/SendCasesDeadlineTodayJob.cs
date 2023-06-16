using Backend.Application.Queries.CaseQueries;
using Backend.Application.Specifications.CaseSpecs;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;
using Quartz;

namespace Backend.Application.Jobs;

[DisallowConcurrentExecution]
public class SendCasesDeadlineTodayJob : IJob
{
    #region Constructor && Properties

    private readonly IRepository<CaseEntity> _repository;
    private readonly INotificationService _notificationService;
    private readonly IExportExcelService _exportExcelService;
    private readonly IMediator _mediator;

    public SendCasesDeadlineTodayJob(IRepository<CaseEntity> repository, INotificationService notificationService,
        IExportExcelService exportExcelService, IMediator mediator)
    {
        _repository = repository;
        _notificationService = notificationService;
        _exportExcelService = exportExcelService;
        _mediator = mediator;
    }

    #endregion

    public async Task Execute(IJobExecutionContext context)
    {
        var today = DateTime.Now;
        var spec = new CaseSpec(today);
        var cases = await _repository.ListAsync(spec, context.CancellationToken);

        var arrayBuffer = await _exportExcelService.GenerateExcelV1(cases);

        var attachemt = new List<string>
        {
            Convert.ToBase64String(arrayBuffer!)
        };
        var attachmentNames = new List<string>();
        attachmentNames.Add($"Reporte_Casos_Por_Vencer_{today.ToShortDateString()}.xlsx");
        _notificationService.SendEmailNotification(new EmailNotifictionModel()
        {
            Subject = "GESTOR DOCUMENTAL - CASOS CON FECHA LIMITE HOY",
            To = "sordonez@dinersclub.com.ec",
            Cc = "tsaabedra@dinersclub.com.ec",
            Attachment = attachemt!,
            AttachmentNames = attachmentNames,
            Body = "<p>A continuación se adjunta el reporte de casos que vencen el día de hoy</p>"
        });
        
    }
}

