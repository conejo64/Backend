using Backend.Application.Queries.BrandQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.BrandRequests;

public class ReadBrandsRequest : BaseFilterDto
{
    public string? Description { get; set; }

    public ReadBrandsQuery ToApplicationRequest()
    {
        return new ReadBrandsQuery(Description, LoadChildren, IsPagingEnabled, Page, PageSize);
    }
}