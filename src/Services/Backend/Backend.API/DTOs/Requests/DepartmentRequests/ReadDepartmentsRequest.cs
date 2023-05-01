using Backend.Application.Queries.DepartmentQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.DepartmentRequests;

public class ReadDepartmentsRequest : BaseFilterDto
{
    public string? Description { get; set; }

    public ReadDepartmentsQuery ToApplicationRequest()
    {
        return new ReadDepartmentsQuery(Description, LoadChildren, IsPagingEnabled, Page, PageSize);
    }
}