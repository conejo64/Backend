using Backend.API.DTOs.Requests.NotificationRequests;
using Backend.API.DTOs.Requests.UserRequests;
using ServiceReference;

namespace Backend.API.Controllers;

public class NotificationsController : BaseController
{
    #region Contructor && Properties

    private readonly IWebHostEnvironment _env;
    public NotificationsController(IMediator mediator, IWebHostEnvironment env) : base(mediator)
    {
        _env = env;
    }

    #endregion   
    

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("sendemail")]
    public async Task<IActionResult> SendEmail([FromBody] EmailNotificationRequest request)
    {
        var command = request.ToApplicationRequest();
        var response = await Mediator.Send(command);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok();
    }
    
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{caseId:guid}/sendCreateNotification")]
    public async Task<IActionResult> SendCreateNotification(Guid caseId)
    {
        var contentRootPath = _env.ContentRootPath;
        var request = new CreateNotificationRequest();
        var command = request.ToApplicationRequest(caseId, contentRootPath);
        var response = await Mediator.Send(command);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok();
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("wcf")]
    public IActionResult Wcf()
    {
        _ = new CallCenterWS2Client();
        return Ok();
    }
}