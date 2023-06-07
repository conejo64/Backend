using Backend.Application.DTOs.Responses.TypeRequirementResponses;
using Backend.Application.Specifications.TypeRequirementSpecs;

namespace Backend.Application.Queries.TypeRequirementQueries;

public class ReadTypeRequirementQueryHandler : IRequestHandler<ReadTypeRequirementQuery, EntityResponse<TypeRequirementResponse>>
{
    private readonly IReadRepository<TypeRequirement> _repository;

    public ReadTypeRequirementQueryHandler(IReadRepository<TypeRequirement> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<TypeRequirementResponse>> Handle(ReadTypeRequirementQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new TypeRequirementSpec(query.Id);
        var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
        if (entity is null)
        {
            return EntityResponse<TypeRequirementResponse>.Error(
                EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
        }

        return TypeRequirementResponse.FromEntity(entity);
    }
}