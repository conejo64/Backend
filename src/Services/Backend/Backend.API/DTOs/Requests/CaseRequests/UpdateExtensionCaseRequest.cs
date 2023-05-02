using Backend.Application.Commands.CaseCommands;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class UpdateExtensionCaseRequest
    {
        public DateTime? ExtensionRequestDate { get; set; }
        public DateTime? NewExtensionRequestDate { get; set; }
        public string? ObservationExtension { get; set; }

        public UpdateExtensionCaseRequest(DateTime? extensionRequestDate, DateTime? newExtensionRequestDate, string? observationExtension)
        {
            ExtensionRequestDate = extensionRequestDate;
            NewExtensionRequestDate = newExtensionRequestDate;
            ObservationExtension = observationExtension;
        }


        public UpdateExtensionCaseCommand ToApplicationRequest(Guid id)
        {
            return new UpdateExtensionCaseCommand(id, ExtensionRequestDate, NewExtensionRequestDate, ObservationExtension);
        }
    }
}
