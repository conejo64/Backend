using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.ProvinceResponses;

namespace Backend.Application.Queries.ProvinceQueries;

public class ReadAllProvincesQuery : IRequest<EntityResponse<List<ProvinceResponse>>>
{
    public ReadAllProvincesQuery()
    {

    }
}