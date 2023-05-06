using Backend.API.DTOs.Requests.TypeRequirementRequests;
using Backend.Application.DTOs.Responses.TypeRequirementResponses;
using Backend.Application.Queries.TypeRequirementQueries;

namespace Backend.API.Controllers;

public class TypeRequirementsController : BaseController
{
    #region Contructor & Properties

    public TypeRequirementsController(IMediator mediator) : base(mediator)
    {
    }

    #endregion

    [HttpGet]
    [JwtAuthorize(JwtScope.Manager)]    
    //[AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(IReadOnlyCollection<TypeRequirementResponse>))]
    [Route("")]
    public async Task<IActionResult> ReadTypeRequirements([FromQuery] ReadTypeRequirementsRequest request)
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
    [JwtAuthorize(JwtScope.Manager)] 
    //[AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(IReadOnlyCollection<TypeRequirementResponse>))]
    [Route("all")]
    public async Task<IActionResult> ReadAllTypeRequirements()
    {
        var query = new ReadAllTypeRequirementsQuery();

        var response = await Mediator.Send(query);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok(response.Value);
    }

    [HttpGet]
    [JwtAuthorize(JwtScope.Manager)] 
    //[AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(TypeRequirementResponse))]
    [Route("{typeId:guid}")]
    public async Task<IActionResult> ReadTypeRequirement(Guid typeId)
    {
        var request = new ReadTypeRequirementRequest(typeId);
        var query = request.ToApplicationRequest();

        var response = await Mediator.Send(query);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok(response.Value);
    }

    [HttpPost]
    [JwtAuthorize(JwtScope.Manager)] 
    //[AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateTypeRequirement([FromBody] CreateTypeRequirementRequest request)
    {
        var command = request.ToApplicationRequest();

        var response = await Mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(ReadTypeRequirement), new { TypeRequirement = response.Value }, response.Value);
    }

    [HttpPut]
    [JwtAuthorize(JwtScope.Manager)]
    //[AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{typeId:guid}")]
    public async Task<IActionResult> UpdateTypeRequirement(Guid typeId,
        [FromBody] UpdateTypeRequirementRequest request)
    {
        var command = request.ToApplicationRequest(typeId);

        var response = await Mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok();
    }

    #region HttDelete Methods

    [HttpDelete]
    [JwtAuthorize(JwtScope.Manager)]    
    //[AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{typeId:guid}")]
    public async Task<IActionResult> DeleteTypeRequirement(Guid typeId)
    {
        var request = new DeleteTypeRequirementRequest();
        var command = request.ToApplicationRequest(typeId);
        var response = await Mediator.Send(command);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response.Value);
    }
    #endregion
}