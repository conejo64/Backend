using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.CaseStatusResponses;
using Backend.Application.Queries.ManagerUserQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.CaseStatusSpecs;

namespace Backend.Application.Queries.CaseStatusQueries;

public class ReadCaseStatussQueryHandler : IRequestHandler<ReadCaseStatussQuery,
    EntityResponse<GetEntitiesResponse<CaseStatusResponse>>>
{
    #region Constructor & Properties

    private readonly IReadRepository<CaseStatus> _repository;

    public ReadCaseStatussQueryHandler(IReadRepository<CaseStatus> repository)
    {
        _repository = repository;
    }

    #endregion

    public async Task<EntityResponse<GetEntitiesResponse<CaseStatusResponse>>> Handle(ReadCaseStatussQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new CaseStatusSpec(query.Description, query.IsPagingEnabled, query.Page, query.PageSize);

        //Get the total amount of entities
        var total = await _repository.CountAsync(spec, cancellationToken);

        //Get entity list
        var entityCollection = await _repository.ListAsync(spec, cancellationToken);

        var filterResponse = new PaginationResponse(query.Page, query.PageSize, total);

        return new GetEntitiesResponse<CaseStatusResponse>(
            entityCollection.Select(CaseStatusResponse.FromEntity).ToList(),
            filterResponse
        );
    }
}