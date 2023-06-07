using Backend.Application.DTOs.Responses.DepartmentResponses;
using Backend.Application.Queries.DepartmentQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.DepartmentSpecs;

namespace Backend.Application.Queries.DepartmentQueries;

public class ReadAllDepartmentsQueryHandler : IRequestHandler<ReadAllDepartmentsQuery,
    EntityResponse<List<DepartmentResponse>>>
{
    private readonly IRepository<Department> _repository;

    public ReadAllDepartmentsQueryHandler(IRepository<Department> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<List<DepartmentResponse>>> Handle(ReadAllDepartmentsQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new DepartmentSpec();

        //Get entity list
        var entityCollection = await _repository.ListAsync(spec, cancellationToken);

        return entityCollection.Select(DepartmentResponse.FromEntity).ToList();
    }
}