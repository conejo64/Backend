using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.BrandResponses;

namespace Backend.Application.Queries.BrandQueries;

public class ReadAllBrandsQuery : IRequest<EntityResponse<List<BrandResponse>>>
{
    public ReadAllBrandsQuery()
    {

    }
}