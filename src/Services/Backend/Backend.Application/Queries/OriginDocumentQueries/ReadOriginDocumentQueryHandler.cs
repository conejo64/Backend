using Backend.Application.DTOs.Responses.OriginDocumentResponses;
using Backend.Application.Specifications.OriginDocumentSpecs;

namespace Backend.Application.Queries.OriginDocumentQueries;

public class ReadOriginDocumentQueryQueryHandler : IRequestHandler<ReadOriginDocumentQuery, EntityResponse<OriginDocumentResponse>>
{
    private readonly IReadRepository<OriginDocument> _repository;

    public ReadOriginDocumentQueryQueryHandler(IReadRepository<OriginDocument> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<OriginDocumentResponse>> Handle(ReadOriginDocumentQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new OriginDocumentSpec(query.Id);
        var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
        if (entity is null)
        {
            return EntityResponse<OriginDocumentResponse>.Error(
                EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
        }

        return OriginDocumentResponse.FromEntity(entity);
    }
}