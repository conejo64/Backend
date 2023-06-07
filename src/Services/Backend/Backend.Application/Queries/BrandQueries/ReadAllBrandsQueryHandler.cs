using Backend.Application.DTOs.Responses.BrandResponses;
using Backend.Application.Queries.BrandQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.BrandSpecs;

namespace Backend.Application.Queries.BrandQueries;

public class ReadAllBrandsQueryHandler : IRequestHandler<ReadAllBrandsQuery,
    EntityResponse<List<BrandResponse>>>
{
    private readonly IRepository<Brand> _repository;

    public ReadAllBrandsQueryHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<List<BrandResponse>>> Handle(ReadAllBrandsQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new BrandSpec();

        //Get entity list
        var entityCollection = await _repository.ListAsync(spec, cancellationToken);

        return entityCollection.Select(BrandResponse.FromEntity).ToList();
    }
}