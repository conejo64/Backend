using Backend.Application.DTOs.Responses.CaseStatusSecretaryResponses;
using Backend.Application.Specifications.CaseStatusSecretarySpecs;

namespace Backend.Application.Queries.CaseStatusSecretaryQueries;

public class ReadCaseStatusSecretaryQueryHandler : IRequestHandler<ReadCaseStatusSecretaryQuery, EntityResponse<CaseStatusSecretaryResponse>>
{
    private readonly IReadRepository<CaseStatusSecretary> _repository;

    public ReadCaseStatusSecretaryQueryHandler(IReadRepository<CaseStatusSecretary> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<CaseStatusSecretaryResponse>> Handle(ReadCaseStatusSecretaryQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new CaseStatusSecretarySpec(query.Id);
        var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
        if (entity is null)
        {
            return EntityResponse<CaseStatusSecretaryResponse>.Error(
                EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
        }

        return CaseStatusSecretaryResponse.FromEntity(entity);
    }
}