using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.BrandResponses;
using Backend.Application.Queries.ManagerUserQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.BrandSpecs;

namespace Backend.Application.Queries.BrandQueries
{
    public class ReadBrandsQueryHandler : IRequestHandler<ReadBrandsQuery,
        EntityResponse<GetEntitiesResponse<BrandResponse>>>
    {
        #region Constructor & Properties

        private readonly IReadRepository<Brand> _repository;

        public ReadBrandsQueryHandler(IReadRepository<Brand> repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<EntityResponse<GetEntitiesResponse<BrandResponse>>> Handle(ReadBrandsQuery query,
            CancellationToken cancellationToken)
        {
            var spec = new BrandSpec(query.Description, query.IsPagingEnabled, query.Page, query.PageSize);

            //Get the total amount of entities
            var total = await _repository.CountAsync(spec, cancellationToken);

            //Get entity list
            var entityCollection = await _repository.ListAsync(spec, cancellationToken);

            var filterResponse = new PaginationResponse(query.Page, query.PageSize, total);

            return new GetEntitiesResponse<BrandResponse>(
                entityCollection.Select(BrandResponse.FromEntity).ToList(),
                filterResponse
            );
        }
    }
}