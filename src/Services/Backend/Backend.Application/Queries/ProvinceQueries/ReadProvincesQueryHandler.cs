using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.ProvinceResponses;
using Backend.Application.Queries.ManagerUserQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.ProvinceSpecs;

namespace Backend.Application.Queries.ProvinceQueries;

public class ReadProvincesQueryHandler : IRequestHandler<ReadProvincesQuery,
    EntityResponse<GetEntitiesResponse<ProvinceResponse>>>
{
    #region Constructor & Properties

    private readonly IReadRepository<Province> _repository;

    public ReadProvincesQueryHandler(IReadRepository<Province> repository)
    {
        _repository = repository;
    }

    #endregion

    public async Task<EntityResponse<GetEntitiesResponse<ProvinceResponse>>> Handle(ReadProvincesQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new ProvinceSpec(query.Description, query.IsPagingEnabled, query.Page, query.PageSize);

        //Get the total amount of entities
        var total = await _repository.CountAsync(spec, cancellationToken);

        //Get entity list
        var entityCollection = await _repository.ListAsync(spec, cancellationToken);

        var filterResponse = new PaginationResponse(query.Page, query.PageSize, total);

        return new GetEntitiesResponse<ProvinceResponse>(
            entityCollection.Select(ProvinceResponse.FromEntity).ToList(),
            filterResponse
        );
    }
}