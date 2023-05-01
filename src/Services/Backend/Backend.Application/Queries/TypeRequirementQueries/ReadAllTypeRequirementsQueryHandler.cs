using Backend.Application.DTOs.Responses.TypeRequirementResponses;
using Backend.Application.Queries.TypeRequirementQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.TypeRequirementSpecs;

namespace Backend.Application.Queries.TypeRequirementQueries
{
    public class ReadAllTypeRequirementsQueryHandler : IRequestHandler<ReadAllTypeRequirementsQuery,
        EntityResponse<List<TypeRequirementResponse>>>
    {
        private readonly IRepository<TypeRequirement> _repository;

        public ReadAllTypeRequirementsQueryHandler(IRepository<TypeRequirement> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<List<TypeRequirementResponse>>> Handle(ReadAllTypeRequirementsQuery query,
            CancellationToken cancellationToken)
        {
            var spec = new TypeRequirementSpec();

            //Get entity list
            var entityCollection = await _repository.ListAsync(spec, cancellationToken);

            return entityCollection.Select(TypeRequirementResponse.FromEntity).ToList();
        }
    }
}