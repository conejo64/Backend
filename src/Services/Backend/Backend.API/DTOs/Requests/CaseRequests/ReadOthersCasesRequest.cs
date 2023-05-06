using Backend.Application.Queries.CaseQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class ReadOthersCasesRequest : BaseFilterDto
    {
        public Guid? OriginDocumentId { get; set; }
        public Guid? CaseStatusId { get; set; }
        public Guid? DepartmentId { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }

        public ReadOthersCasesQuery ToApplicationRequest(Guid userId)
        {
            return new ReadOthersCasesQuery(userId, OriginDocumentId, CaseStatusId, DepartmentId, InitialDate, FinalDate, LoadChildren, IsPagingEnabled, Page, PageSize);
        }
    }
}
