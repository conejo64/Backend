using Backend.Application.DTOs.Responses.DashboardResponses;

namespace Backend.Application.Queries.DashboardQueries;

public class ReadDashboardQuery : IRequest<EntityResponse<DashboardResponse>>
{
    public ReadDashboardQuery()
    {
    }
}