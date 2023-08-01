using Backend.Application.DTOs.Responses.DashboardResponses;
using Backend.Application.Queries.DashboardQueries;

namespace Backend.API.Controllers;

public class DashboardController: BaseController
{
    #region Contructor & Properties

    public DashboardController(IMediator mediator) : base(mediator)
    {
    }

    #endregion

    [HttpGet]
    // [JwtAuthorize(JwtScope.Manager)] 
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(IReadOnlyCollection<DashboardResponse>))]
    public async Task<IActionResult> ReadTotals()
    {
        var query = new ReadDashboardQuery();

        var response = await Mediator.Send(query);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok(response.Value);
    }
}