using Backend.Application.Queries.TypeRequirementQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.TypeRequirementRequests;

public class ReadTypeRequirementsRequest : BaseFilterDto
{
    public string? Description { get; set; }

    public ReadTypeRequirementsQuery ToApplicationRequest()
    {
        return new ReadTypeRequirementsQuery(Description, LoadChildren, IsPagingEnabled, Page, PageSize);
    }
}