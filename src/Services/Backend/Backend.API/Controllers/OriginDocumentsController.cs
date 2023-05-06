using Backend.API.DTOs.Requests.OriginDocumentRequests;
using Backend.Application.DTOs.Responses.OriginDocumentResponses;
using Backend.Application.Queries.OriginDocumentQueries;

namespace Backend.API.Controllers;

public class OriginDocumentsController : BaseController
{
    #region Contructor & Properties

    public OriginDocumentsController(IMediator mediator) : base(mediator)
    {
    }

    #endregion

    [HttpGet]
    [JwtAuthorize(JwtScope.Manager)]    
    //[AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(IReadOnlyCollection<OriginDocumentResponse>))]
    [Route("")]
    public async Task<IActionResult> ReadOriginDocuments([FromQuery] ReadOriginDocumentsRequest request)
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
    [Produces(typeof(IReadOnlyCollection<OriginDocumentResponse>))]
    [Route("all")]
    public async Task<IActionResult> ReadAllOriginDocuments()
    {
        var query = new ReadAllOriginDocumentsQuery();

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
    [Produces(typeof(OriginDocumentResponse))]
    [Route("{originDocumentId:guid}")]
    public async Task<IActionResult> ReadOriginDocument(Guid originDocumentId)
    {
        var request = new ReadOriginDocumentRequest(originDocumentId);
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
    public async Task<IActionResult> CreateOriginDocument([FromBody] CreateOriginDocumentRequest request)
    {
        var command = request.ToApplicationRequest();

        var response = await Mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(ReadOriginDocument), new { OriginDocument = response.Value }, response.Value);
    }

    [HttpPut]
    [JwtAuthorize(JwtScope.Manager)]
    //[AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{originDocumentId:guid}")]
    public async Task<IActionResult> UpdateOriginDocument(Guid originDocumentId,
        [FromBody] UpdateOriginDocumentRequest request)
    {
        var command = request.ToApplicationRequest(originDocumentId);

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
    [Route("{originDocumentId:guid}")]
    public async Task<IActionResult> DeleteOriginDocument(Guid originDocumentId)
    {
        var request = new DeleteOriginDocumentRequest();
        var command = request.ToApplicationRequest(originDocumentId);
        var response = await Mediator.Send(command);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response.Value);
    }
    #endregion
}