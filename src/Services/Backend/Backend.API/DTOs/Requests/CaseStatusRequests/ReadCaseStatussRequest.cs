using Backend.Application.Queries.CaseStatusQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.CaseStatusRequests;

public class ReadCaseStatussRequest : BaseFilterDto
{
    public string? Description { get; set; }

    public ReadCaseStatussQuery ToApplicationRequest()
    {
        return new ReadCaseStatussQuery(Description, LoadChildren, IsPagingEnabled, Page, PageSize);
    }
}