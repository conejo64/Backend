using Backend.Application.DTOs.Responses.DepartmentResponses;
using Backend.Application.Specifications.DepartmentSpecs;

namespace Backend.Application.Queries.DepartmentQueries;

public class ReadDepartmentQueryHandler : IRequestHandler<ReadDepartmentQuery, EntityResponse<DepartmentResponse>>
{
    private readonly IReadRepository<Department> _repository;

    public ReadDepartmentQueryHandler(IReadRepository<Department> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<DepartmentResponse>> Handle(ReadDepartmentQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new DepartmentSpec(query.Id);
        var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
        if (entity is null)
        {
            return EntityResponse<DepartmentResponse>.Error(
                EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
        }

        return DepartmentResponse.FromEntity(entity);
    }
}