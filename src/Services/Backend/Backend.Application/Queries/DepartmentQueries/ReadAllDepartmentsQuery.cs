using Backend.Application.DTOs.Responses.DepartmentResponses;

namespace Backend.Application.Queries.DepartmentQueries;

public class ReadAllDepartmentsQuery : IRequest<EntityResponse<List<DepartmentResponse>>>
{
    public ReadAllDepartmentsQuery()
    {

    }
}