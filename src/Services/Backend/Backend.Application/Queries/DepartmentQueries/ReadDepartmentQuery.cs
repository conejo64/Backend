using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.DepartmentResponses;

namespace Backend.Application.Queries.DepartmentQueries;

public class ReadDepartmentQuery : IRequest<EntityResponse<DepartmentResponse>>
{
    public Guid Id { get; }

    public ReadDepartmentQuery(Guid id)
    {
        Id= id;
    }
}