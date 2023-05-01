using Backend.API.DTOs.Requests.CaseStatusRequests;
using Backend.Application.DTOs.Responses.CaseStatusResponses;
using Backend.Application.Queries.CaseStatusQueries;

namespace Backend.API.Controllers;

public class CaseStatussController : BaseController
{
    #region Contructor & Properties

    public CaseStatussController(IMediator mediator) : base(mediator)
    {
    }

    #endregion

    [HttpGet]
    // [JwtAuthorize(JwtScope.Manager)]    
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(IReadOnlyCollection<CaseStatusResponse>))]
    [Route("")]
    public async Task<IActionResult> ReadCaseStatuss([FromQuery] ReadCaseStatussRequest request)
    {
        var query = request.ToApplicationRequest();

        var response = await Mediator.Send(query);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok(response.Value);
    }

    [HttpGet]
    // [JwtAuthorize(JwtScope.Manager)] 
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(IReadOnlyCollection<CaseStatusResponse>))]
    [Route("all")]
    public async Task<IActionResult> ReadAllCaseStatuss()
    {
        var query = new ReadAllCaseStatussQuery();

        var response = await Mediator.Send(query);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok(response.Value);
    }

    [HttpGet]
    // [JwtAuthorize(JwtScope.Manager)] 
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(CaseStatusResponse))]
    [Route("{caseId:guid}")]
    public async Task<IActionResult> ReadCaseStatus(Guid caseId)
    {
        var request = new ReadCaseStatusRequest(caseId);
        var query = request.ToApplicationRequest();

        var response = await Mediator.Send(query);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok(response.Value);
    }

    [HttpPost]
    // [JwtAuthorize(JwtScope.Manager)] 
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateCaseStatus([FromBody] CreateCaseStatusRequest request)
    {
        var command = request.ToApplicationRequest();

        var response = await Mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(ReadCaseStatus), new { CaseStatus = response.Value }, response.Value);
    }

    [HttpPut]
    // [JwtAuthorize(JwtScope.Manager)]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{caseId:guid}")]
    public async Task<IActionResult> UpdateCaseStatus(Guid caseId,
        [FromBody] UpdateCaseStatusRequest request)
    {
        var command = request.ToApplicationRequest(caseId);

        var response = await Mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok();
    }

    #region HttDelete Methods

    [HttpDelete]
    // [JwtAuthorize(JwtScope.Manager)]    
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{caseId:guid}")]
    public async Task<IActionResult> DeleteCaseStatus(Guid caseId)
    {
        var request = new DeleteCaseStatusRequest();
        var command = request.ToApplicationRequest(caseId);
        var response = await Mediator.Send(command);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response.Value);
    }
    #endregion
}