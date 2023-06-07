using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.TypeRequirementResponses;

namespace Backend.Application.Queries.TypeRequirementQueries;

public class ReadTypeRequirementQuery : IRequest<EntityResponse<TypeRequirementResponse>>
{
    public Guid Id { get; }

    public ReadTypeRequirementQuery(Guid id)
    {
        Id= id;
    }
}