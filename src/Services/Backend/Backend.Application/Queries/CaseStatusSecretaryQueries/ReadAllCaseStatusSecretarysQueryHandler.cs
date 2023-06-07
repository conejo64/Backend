using Backend.Application.DTOs.Responses.CaseStatusSecretaryResponses;
using Backend.Application.Queries.CaseStatusSecretaryQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.CaseStatusSecretarySpecs;

namespace Backend.Application.Queries.CaseStatusSecretaryQueries;

public class ReadAllCaseStatusSecretarysQueryHandler : IRequestHandler<ReadAllCaseStatusSecretarysQuery,
    EntityResponse<List<CaseStatusSecretaryResponse>>>
{
    private readonly IRepository<CaseStatusSecretary> _repository;

    public ReadAllCaseStatusSecretarysQueryHandler(IRepository<CaseStatusSecretary> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<List<CaseStatusSecretaryResponse>>> Handle(ReadAllCaseStatusSecretarysQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new CaseStatusSecretarySpec();

        //Get entity list
        var entityCollection = await _repository.ListAsync(spec, cancellationToken);

        return entityCollection.Select(CaseStatusSecretaryResponse.FromEntity).ToList();
    }
}