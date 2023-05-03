using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.OriginDocumentResponses;
using Backend.Application.Specifications.MemberSpecs;

namespace Backend.Application.Queries.ManagerUserQueries
{
    public class ReadManagerUsersQueryHandler : IRequestHandler<ReadManagerUsersQuery,
        EntityResponse<GetEntitiesResponse<ReadUsersResponse>>>
    {
        #region Constructor & Properties

        private readonly IReadRepository<User> _repository;

        public ReadManagerUsersQueryHandler(IReadRepository<User> repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<EntityResponse<GetEntitiesResponse<ReadUsersResponse>>> Handle(ReadManagerUsersQuery query,
            CancellationToken cancellationToken)
        {
            var spec = new ManagerSpec(query.QueryParam, query.IsPagingEnabled, query.Page, query.PageSize);

            //Get the total amount of entities
            var total = await _repository.CountAsync(spec, cancellationToken);

            //Get entity list
            var entityCollection = await _repository.ListAsync(spec, cancellationToken);

            var filterResponse = new PaginationResponse(query.Page, query.PageSize, total);

            return new GetEntitiesResponse<ReadUsersResponse>(
                entityCollection.Select(ReadUsersResponse.FromEntity).ToList(),
                filterResponse
            );
        }
    }
}