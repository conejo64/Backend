using Backend.Application.DTOs.Responses.CaseStatusResponses;
using Backend.Application.Specifications.CaseStatusSpecs;

namespace Backend.Application.Queries.CaseStatusQueries;

public class ReadCaseStatusQueryHandler : IRequestHandler<ReadCaseStatusQuery, EntityResponse<CaseStatusResponse>>
{
    private readonly IReadRepository<CaseStatus> _repository;

    public ReadCaseStatusQueryHandler(IReadRepository<CaseStatus> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<CaseStatusResponse>> Handle(ReadCaseStatusQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new CaseStatusSpec(query.Id);
        var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
        if (entity is null)
        {
            return EntityResponse<CaseStatusResponse>.Error(
                EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
        }

        return CaseStatusResponse.FromEntity(entity);
    }
}