using Backend.Application.DTOs.Responses.CaseResponses;
using Shared.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Queries.CaseQueries
{
    public class ReadCasesToExcelQuery : BaseFilter, IRequest<EntityResponse<byte[]>>
    {
        public Guid? OriginDocumentId { get; set; }
        public Guid? CaseStatusId { get; set; }
        public Guid? DepartmentId { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }


        public ReadCasesToExcelQuery(Guid? originDocumentId, Guid? caseStatusId, Guid? departmentId, DateTime? initialDate, DateTime? finalDate)
        {
            OriginDocumentId = originDocumentId;
            CaseStatusId = caseStatusId;
            DepartmentId = departmentId;
            InitialDate = initialDate;
            FinalDate = finalDate;
        }
    }
}
