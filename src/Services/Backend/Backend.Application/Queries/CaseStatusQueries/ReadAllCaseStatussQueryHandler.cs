using Backend.Application.DTOs.Responses.CaseStatusResponses;
using Backend.Application.Queries.CaseStatusQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.CaseStatusSpecs;

namespace Backend.Application.Queries.CaseStatusQueries;

public class ReadAllCaseStatussQueryHandler : IRequestHandler<ReadAllCaseStatussQuery,
    EntityResponse<List<CaseStatusResponse>>>
{
    private readonly IRepository<CaseStatus> _repository;

    public ReadAllCaseStatussQueryHandler(IRepository<CaseStatus> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<List<CaseStatusResponse>>> Handle(ReadAllCaseStatussQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new CaseStatusSpec();

        //Get entity list
        var entityCollection = await _repository.ListAsync(spec, cancellationToken);

        return entityCollection.Select(CaseStatusResponse.FromEntity).ToList();
    }
}