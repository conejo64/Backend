using Backend.Application.Queries.DepartmentQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.DepartmentRequests;

public class ReadDepartmentRequest
{
    private Guid Id { get; }

    public ReadDepartmentRequest(Guid id)
    {
        Id = id;
    }

    public ReadDepartmentQuery ToApplicationRequest()
    {
        return new ReadDepartmentQuery(Id);
    }
}