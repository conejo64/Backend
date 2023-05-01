using Backend.API.DTOs.Requests.CaseStatusSecretaryRequests;
using Backend.Application.DTOs.Responses.CaseStatusSecretaryResponses;
using Backend.Application.Queries.CaseStatusSecretaryQueries;

namespace Backend.API.Controllers;

public class CaseStatusSecretarysController : BaseController
{
    #region Contructor & Properties

    public CaseStatusSecretarysController(IMediator mediator) : base(mediator)
    {
    }

    #endregion

    [HttpGet]
    // [JwtAuthorize(JwtScope.Manager)]    
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(IReadOnlyCollection<CaseStatusSecretaryResponse>))]
    [Route("")]
    public async Task<IActionResult> ReadCaseStatusSecretarys([FromQuery] ReadCaseStatusSecretarysRequest request)
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
    [Produces(typeof(IReadOnlyCollection<CaseStatusSecretaryResponse>))]
    [Route("all")]
    public async Task<IActionResult> ReadAllCaseStatusSecretarys()
    {
        var query = new ReadAllCaseStatusSecretarysQuery();

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
    [Produces(typeof(CaseStatusSecretaryResponse))]
    [Route("{caseId:guid}")]
    public async Task<IActionResult> ReadCaseStatusSecretary(Guid caseId)
    {
        var request = new ReadCaseStatusSecretaryRequest(caseId);
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
    public async Task<IActionResult> CreateCaseStatusSecretary([FromBody] CreateCaseStatusSecretaryRequest request)
    {
        var command = request.ToApplicationRequest();

        var response = await Mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(ReadCaseStatusSecretary), new { CaseStatusSecretary = response.Value }, response.Value);
    }

    [HttpPut]
    // [JwtAuthorize(JwtScope.Manager)]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{caseId:guid}")]
    public async Task<IActionResult> UpdateCaseStatusSecretary(Guid caseId,
        [FromBody] UpdateCaseStatusSecretaryRequest request)
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
    public async Task<IActionResult> DeleteCaseStatusSecretary(Guid caseId)
    {
        var request = new DeleteCaseStatusSecretaryRequest();
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