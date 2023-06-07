using Backend.Application.DTOs.Responses.ProvinceResponses;
using Backend.Application.Queries.ProvinceQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.ProvinceSpecs;

namespace Backend.Application.Queries.ProvinceQueries;

public class ReadAllProvincesQueryHandler : IRequestHandler<ReadAllProvincesQuery,
    EntityResponse<List<ProvinceResponse>>>
{
    private readonly IRepository<Province> _repository;

    public ReadAllProvincesQueryHandler(IRepository<Province> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<List<ProvinceResponse>>> Handle(ReadAllProvincesQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new ProvinceSpec();

        //Get entity list
        var entityCollection = await _repository.ListAsync(spec, cancellationToken);

        return entityCollection.Select(ProvinceResponse.FromEntity).ToList();
    }
}