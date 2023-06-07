using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands;

public class UpdateExtensionCaseCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; }
    //Screen Prorrogation
    public DateTime? ExtensionRequestDate { get; set; }
    public DateTime? NewExtensionRequestDate { get; set; }
    public string? ObservationExtension { get; set; }

    public UpdateExtensionCaseCommand(Guid id, DateTime? extensionRequestDate, DateTime? newExtensionRequestDate, string? observationExtension)
    {
        Id = id;
        ExtensionRequestDate = extensionRequestDate;
        NewExtensionRequestDate = newExtensionRequestDate;
        ObservationExtension = observationExtension;
    }
}