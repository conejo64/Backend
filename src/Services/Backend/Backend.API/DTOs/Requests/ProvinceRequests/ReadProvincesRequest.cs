using Backend.Application.Queries.ProvinceQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.ProvinceRequests;

public class ReadProvincesRequest : BaseFilterDto
{
    public string? Description { get; set; }

    public ReadProvincesQuery ToApplicationRequest()
    {
        return new ReadProvincesQuery(Description, LoadChildren, IsPagingEnabled, Page, PageSize);
    }
}