using Backend.Application.DTOs.Responses.OriginDocumentResponses;
using Backend.Application.Queries.OriginDocumentQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.OriginDocumentSpecs;

namespace Backend.Application.Queries.OriginDocumentQueries
{
    public class ReadAllBrandsQueryHandler : IRequestHandler<ReadAllOriginDocumentsQuery,
        EntityResponse<List<OriginDocumentResponse>>>
    {
        private readonly IRepository<OriginDocument> _repository;

        public ReadAllBrandsQueryHandler(IRepository<OriginDocument> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<List<OriginDocumentResponse>>> Handle(ReadAllOriginDocumentsQuery query,
            CancellationToken cancellationToken)
        {
            var spec = new OriginDocumentSpec();

            //Get entity list
            var entityCollection = await _repository.ListAsync(spec, cancellationToken);

            return entityCollection.Select(OriginDocumentResponse.FromEntity).ToList();
        }
    }
}