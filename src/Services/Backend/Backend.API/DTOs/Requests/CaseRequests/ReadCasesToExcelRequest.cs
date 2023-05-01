using Backend.Application.Queries.CaseQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class ReadCasesToExcelRequest : BaseFilterDto
    {
        public Guid? BrandId { get; set; }
        public Guid? CaseStatusId { get; set; }
        public Guid? DepartmentId { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }

        public ReadCasesToExcelQuery ToApplicationRequest()
        {
            return new ReadCasesToExcelQuery(BrandId, CaseStatusId, DepartmentId, InitialDate, FinalDate, LoadChildren, IsPagingEnabled, Page, PageSize);
        }
    }
}
