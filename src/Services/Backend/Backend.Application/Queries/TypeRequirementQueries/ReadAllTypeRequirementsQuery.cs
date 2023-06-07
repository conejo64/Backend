using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.TypeRequirementResponses;

namespace Backend.Application.Queries.TypeRequirementQueries;

public class ReadAllTypeRequirementsQuery : IRequest<EntityResponse<List<TypeRequirementResponse>>>
{
    public ReadAllTypeRequirementsQuery()
    {

    }
}