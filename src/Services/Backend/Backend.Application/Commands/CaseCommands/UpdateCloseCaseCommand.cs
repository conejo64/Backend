using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands
{
    public class UpdateCloseCaseCommand : IRequest<EntityResponse<bool>>
    {
        public Guid Id { get; }
        //Screen Close Secretary
        public DateTime? ResponseDate { get; set; }
        public Guid? CaseStatusId { get; set; }
        public string? ObservationDepartment { get; set; }
        public Guid? CaseStatusSecretaryId { get; set; }
        public DateTime? AcknowledgmentDate { get; set; }

        public UpdateCloseCaseCommand(Guid id, DateTime? responseDate, Guid? caseStatusId, string? observationDepartment, Guid? caseStatusSecretaryId, DateTime? acknowledgmentDate)
        {
            Id = id;
            ResponseDate = responseDate;
            CaseStatusId = caseStatusId;
            ObservationDepartment = observationDepartment;
            CaseStatusSecretaryId = caseStatusSecretaryId;
            AcknowledgmentDate = acknowledgmentDate;
        }
    }
}
