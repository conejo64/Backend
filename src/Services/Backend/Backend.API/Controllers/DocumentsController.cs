using Backend.API.DTOs.Requests.CaseRequests;
using Backend.API.DTOs.Requests.DocumentRequests;
using Backend.Application.DTOs.Responses.CaseResponses;
using Backend.Application.DTOs.Responses.DocumentResponses;
using Backend.Application.Queries.CaseQueries;
using Backend.Domain.Entities;

namespace Backend.API.Controllers;

public class DocumentsController : BaseController
{
    #region Contructor & Properties

    private readonly IMediator _mediator;
    private readonly IWebHostEnvironment _env;

    public DocumentsController(IMediator mediator, IWebHostEnvironment env) : base(mediator)
    {
        _mediator = mediator;
        _env = env;
    }

    #endregion

    [HttpPost]
    //[JwtAuthorize(JwtScope.Manager)] 
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UploadDocument([FromBody] UploadDocumentRequest request)
    {
        // var claim = HttpContext.User.Claims.FirstOrDefault(t => t.Type.Equals("id"));
        // var claimValue = claim?.Value;
        // if (claimValue == null)
        // {
        //     return BadRequest();
        // }
        var contentRootPath = _env.ContentRootPath;
        var command = request.ToApplicationRequest(contentRootPath);

        var response = await _mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return Ok(response.Value);
    }
}