using Backend.Application.DTOs.Responses.BrandResponses;
using Backend.Application.Specifications.BrandSpecs;

namespace Backend.Application.Queries.BrandQueries
{
    public class ReadBrandQueryHandler : IRequestHandler<ReadBrandQuery, EntityResponse<BrandResponse>>
    {
        private readonly IReadRepository<Brand> _repository;

        public ReadBrandQueryHandler(IReadRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<BrandResponse>> Handle(ReadBrandQuery query,
            CancellationToken cancellationToken)
        {
            var spec = new BrandSpec(query.Id);
            var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
            if (entity is null)
            {
                return EntityResponse<BrandResponse>.Error(
                    EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
            }

            return BrandResponse.FromEntity(entity);
        }
    }
}