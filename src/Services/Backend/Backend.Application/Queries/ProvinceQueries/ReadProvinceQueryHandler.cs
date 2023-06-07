using Backend.Application.DTOs.Responses.ProvinceResponses;
using Backend.Application.Specifications.ProvinceSpecs;

namespace Backend.Application.Queries.ProvinceQueries;

public class ReadProvinceQueryHandler : IRequestHandler<ReadProvinceQuery, EntityResponse<ProvinceResponse>>
{
    private readonly IReadRepository<Province> _repository;

    public ReadProvinceQueryHandler(IReadRepository<Province> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<ProvinceResponse>> Handle(ReadProvinceQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new ProvinceSpec(query.Id);
        var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
        if (entity is null)
        {
            return EntityResponse<ProvinceResponse>.Error(
                EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
        }

        return ProvinceResponse.FromEntity(entity);
    }
}