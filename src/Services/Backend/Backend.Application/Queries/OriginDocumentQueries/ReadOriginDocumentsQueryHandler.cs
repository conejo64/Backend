using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.OriginDocumentResponses;
using Backend.Application.Queries.ManagerUserQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.OriginDocumentSpecs;

namespace Backend.Application.Queries.OriginDocumentQueries
{
    public class ReadOriginDocumentsQueryHandler : IRequestHandler<ReadOriginDocumentsQuery,
        EntityResponse<GetEntitiesResponse<OriginDocumentResponse>>>
    {
        #region Constructor & Properties

        private readonly IReadRepository<OriginDocument> _repository;

        public ReadOriginDocumentsQueryHandler(IReadRepository<OriginDocument> repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<EntityResponse<GetEntitiesResponse<OriginDocumentResponse>>> Handle(ReadOriginDocumentsQuery query,
            CancellationToken cancellationToken)
        {
            var spec = new OriginDocumentSpec(query.Description, query.IsPagingEnabled, query.Page, query.PageSize);

            //Get the total amount of entities
            var total = await _repository.CountAsync(spec, cancellationToken);

            //Get entity list
            var entityCollection = await _repository.ListAsync(spec, cancellationToken);

            var filterResponse = new PaginationResponse(query.Page, query.PageSize, total);

            return new GetEntitiesResponse<OriginDocumentResponse>(
                entityCollection.Select(OriginDocumentResponse.FromEntity).ToList(),
                filterResponse
            );
        }
    }
}