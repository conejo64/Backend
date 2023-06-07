using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.DepartmentResponses;
using Backend.Application.Queries.ManagerUserQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.DepartmentSpecs;

namespace Backend.Application.Queries.DepartmentQueries;

public class ReadDepartmentsQueryHandler : IRequestHandler<ReadDepartmentsQuery,
    EntityResponse<GetEntitiesResponse<DepartmentResponse>>>
{
    #region Constructor & Properties

    private readonly IReadRepository<Department> _repository;

    public ReadDepartmentsQueryHandler(IReadRepository<Department> repository)
    {
        _repository = repository;
    }

    #endregion

    public async Task<EntityResponse<GetEntitiesResponse<DepartmentResponse>>> Handle(ReadDepartmentsQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new DepartmentSpec(query.Description, query.IsPagingEnabled, query.Page, query.PageSize);

        //Get the total amount of entities
        var total = await _repository.CountAsync(spec, cancellationToken);

        //Get entity list
        var entityCollection = await _repository.ListAsync(spec, cancellationToken);

        var filterResponse = new PaginationResponse(query.Page, query.PageSize, total);

        return new GetEntitiesResponse<DepartmentResponse>(
            entityCollection.Select(DepartmentResponse.FromEntity).ToList(),
            filterResponse
        );
    }
}