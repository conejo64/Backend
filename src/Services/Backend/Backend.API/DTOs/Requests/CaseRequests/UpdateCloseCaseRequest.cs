using Backend.Application.Commands.CaseCommands;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class UpdateCloseCaseRequest
    {
        public DateTime? ResponseDate { get; set; }
        public Guid? CaseStatusId { get; set; }
        public string? ObservationDepartment { get; set; }
        public Guid? CaseStatusSecretaryId { get; set; }
        public DateTime? AcknowledgmentDate { get; set; }

        public UpdateCloseCaseRequest(DateTime? responseDate, Guid? caseStatusId, string? observationDepartment, Guid? caseStatusSecretaryId, DateTime? acknowledgmentDate)
        {
            ResponseDate = responseDate;
            CaseStatusId = caseStatusId;
            ObservationDepartment = observationDepartment;
            CaseStatusSecretaryId = caseStatusSecretaryId;
            AcknowledgmentDate = acknowledgmentDate;
        }

        public UpdateCloseCaseCommand ToApplicationRequest(Guid id)
        {
            return new UpdateCloseCaseCommand(id, ResponseDate, CaseStatusId, ObservationDepartment, CaseStatusSecretaryId, AcknowledgmentDate);
        }
    }
}
