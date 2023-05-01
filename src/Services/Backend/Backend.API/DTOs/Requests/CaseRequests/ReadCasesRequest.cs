using Backend.Application.Queries.CaseQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class ReadCasesRequest : BaseFilterDto
    {
        public Guid? BrandId { get; set; }
        public Guid? CaseStatusId { get; set; }
        public Guid? DepartmentId { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }

        public ReadCasesQuery ToApplicationRequest()
        {
            return new ReadCasesQuery(BrandId, CaseStatusId, DepartmentId, InitialDate, FinalDate, LoadChildren, IsPagingEnabled, Page, PageSize);
        }
    }
}
