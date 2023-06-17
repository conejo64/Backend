using Backend.API.DTOs.Requests.CaseRequests;
using Backend.Application.DTOs.Responses.CaseResponses;
using Backend.Application.DTOs.Responses.DocumentResponses;
using Backend.Application.Queries.CaseQueries;
using Backend.Domain.Entities;

namespace Backend.API.Controllers;

public class CasesController : BaseController
{
    #region Contructor & Properties

    private readonly IMediator _mediator;
    private readonly IWebHostEnvironment _env;

    public CasesController(IMediator mediator, IWebHostEnvironment env) : base(mediator)
    {
        _mediator = mediator;
        _env = env;
    }

    #endregion

    [HttpGet]
    [JwtAuthorize(JwtScope.Manager)]    
    // [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(IReadOnlyCollection<CaseResponse>))]
    [Route("")]
    public async Task<IActionResult> ReadCases([FromQuery] ReadCasesRequest request)
    {

        var query = request.ToApplicationRequest();

        var response = await _mediator.Send(query);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok(response.Value);
    }

    [HttpGet]
    [JwtAuthorize(JwtScope.Manager)]
    // [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(IReadOnlyCollection<CaseResponse>))]
    [Route("others")]
    public async Task<IActionResult> ReadOthersCases([FromQuery] ReadOthersCasesRequest request)
    {
        var claim = HttpContext.User.Claims.FirstOrDefault(t => t.Type.Equals("id"));
        var claimValue = claim?.Value;
        if (claimValue == null)
        {
            return BadRequest();
        }
        var userId = Guid.Parse(claimValue);
        var query = request.ToApplicationRequest(userId);

        var response = await _mediator.Send(query);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok(response.Value);
    }

    [HttpGet]
    [JwtAuthorize(JwtScope.Manager)] 
    // [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(IReadOnlyCollection<CaseResponse>))]
    [Route("all")]
    public async Task<IActionResult> ReadAllCases()
    {
        var query = new ReadAllCasesQuery();

        var response = await _mediator.Send(query);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok(response.Value);
    }

    [HttpGet]
    [JwtAuthorize(JwtScope.Manager)] 
    // [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(CaseResponse))]
    [Route("{caseId:guid}")]
    public async Task<IActionResult> ReadCase(Guid caseId)
    {
        var request = new ReadCaseRequest(caseId);
        var query = request.ToApplicationRequest();

        var response = await _mediator.Send(query);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok(response.Value);
    }

    [HttpPost]
    //[JwtAuthorize(JwtScope.Manager)] 
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateCase([FromBody] CreateCaseRequest request)
    {
        var claim = HttpContext.User.Claims.FirstOrDefault(t => t.Type.Equals("id"));
        var claimValue = claim?.Value;
        if (claimValue == null)
        {
            return BadRequest();
        }
        var contentRootPath = _env.ContentRootPath;
        var userId = Guid.Parse(claimValue);
        var command = request.ToApplicationRequest(userId, contentRootPath);

        var response = await _mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(ReadCase), new { CaseEntity = response.Value }, response.Value);
    }

    [HttpPut]
    [JwtAuthorize(JwtScope.Manager)]
    // [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{caseId:guid}")]
    public async Task<IActionResult> UpdateCase(Guid caseId,
        [FromBody] UpdateCaseRequest request)
    {
        var command = request.ToApplicationRequest(caseId);

        var response = await _mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok();
    }

    #region HttDelete Methods

    [HttpDelete]
    [JwtAuthorize(JwtScope.Manager)]    
    // [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{caseId:guid}")]
    public async Task<IActionResult> DeleteCase(Guid caseId)
    {
        var request = new DeleteCaseRequest();
        var command = request.ToApplicationRequest(caseId);
        var response = await _mediator.Send(command);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response.Value);
    }
    #endregion
    
    [HttpPost]
    [JwtAuthorize(JwtScope.Manager)]
    // [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{caseId:guid}/extend")]
    public async Task<IActionResult> UpdateExtensionCase(Guid caseId,
        [FromBody] UpdateExtensionCaseRequest request)
    {
        var command = request.ToApplicationRequest(caseId);

        var response = await _mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok();
    }
    
    [HttpPost]
    [JwtAuthorize(JwtScope.Manager)]
    // [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{caseId:guid}/close")]
    public async Task<IActionResult> UpdateCloseCase(Guid caseId,
        [FromBody] UpdateCloseCaseRequest request)
    {
        var contentRootPath = _env.ContentRootPath;
        var command = request.ToApplicationRequest(caseId, contentRootPath);

        var response = await _mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok();
    }
    
    [HttpPost]
    [JwtAuthorize(JwtScope.Manager)]
    // [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{caseId:guid}/reply")]
    public async Task<IActionResult> UpdateReplyCase(Guid caseId,
        [FromBody] UpdateReplyCaseRequest request)
    {
        var contentRootPath = _env.ContentRootPath;
        var command = request.ToApplicationRequest(caseId, contentRootPath);

        var response = await _mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok();
    }
    
    [HttpPost]
    [JwtAuthorize(JwtScope.Manager)]
    // [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{caseId:guid}/information")]
    public async Task<IActionResult> UpdateInformationCase(Guid caseId,
        [FromBody] UpdateInformationCaseRequest request)
    {
        var command = request.ToApplicationRequest(caseId);

        var response = await _mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok();
    }
    
    [HttpPost]
    [JwtAuthorize(JwtScope.Manager)]
    // [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{caseId:guid}/notification")]
    public async Task<IActionResult> SendNotificationCase(Guid caseId,
        [FromBody] SendNotificationCaseRequest request)
    {
        var command = request.ToApplicationRequest(caseId);

        var response = await _mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok();
    }
    
    [HttpGet]
    [JwtAuthorize(JwtScope.Manager)] 
    // [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(List<DocumentResponse>))]
    [Route("{caseId:guid}/attachments")]
    public async Task<IActionResult> ReadAttachmentsCase(Guid caseId)
    {
        var request = new ReadCaseDocumentsRequest(caseId);
        var query = request.ToApplicationRequest();

        var response = await _mediator.Send(query);
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
    [Produces(typeof(List<DocumentResponse>))]
    [Route("{caseId:guid}/attachment/{attachmentId:guid}")]
    public async Task<IActionResult> ReadAttachmentsCase(Guid caseId, Guid attachmentId)
    {
        var contentRootPath = _env.ContentRootPath;
        var request = new ReadCaseDocumentRequest(caseId, attachmentId);
        var query = request.ToApplicationRequest(contentRootPath);

        var response = await _mediator.Send(query);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }
        
        var contentType = response.Value!.ContentType;
        var byteAttachment = Convert.FromBase64String(response.Value.Document64!);
        return File(byteAttachment, contentType!, response.Value.Document64Name);
    }
}