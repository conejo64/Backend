using Backend.API.DTOs.Requests.ProvinceRequests;
using Backend.Application.DTOs.Responses.ProvinceResponses;
using Backend.Application.Queries.ProvinceQueries;

namespace Backend.API.Controllers;

public class ProvincesController : BaseController
{
    #region Contructor & Properties

    public ProvincesController(IMediator mediator) : base(mediator)
    {
    }

    #endregion

    [HttpGet]
    // [JwtAuthorize(JwtScope.Manager)]    
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(IReadOnlyCollection<ProvinceResponse>))]
    [Route("")]
    public async Task<IActionResult> ReadProvinces([FromQuery] ReadProvincesRequest request)
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
    [Produces(typeof(IReadOnlyCollection<ProvinceResponse>))]
    [Route("all")]
    public async Task<IActionResult> ReadAllProvinces()
    {
        var query = new ReadAllProvincesQuery();

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
    [Produces(typeof(ProvinceResponse))]
    [Route("{provinceId:guid}")]
    public async Task<IActionResult> ReadProvince(Guid provinceId)
    {
        var request = new ReadProvinceRequest(provinceId);
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
    public async Task<IActionResult> CreateProvince([FromBody] CreateProvinceRequest request)
    {
        var command = request.ToApplicationRequest();

        var response = await Mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(ReadProvince), new { Province = response.Value }, response.Value);
    }

    [HttpPut]
    // [JwtAuthorize(JwtScope.Manager)]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{provinceId:guid}")]
    public async Task<IActionResult> UpdateProvince(Guid provinceId,
        [FromBody] UpdateProvinceRequest request)
    {
        var command = request.ToApplicationRequest(provinceId);

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
    [Route("{provinceId:guid}")]
    public async Task<IActionResult> DeleteProvince(Guid provinceId)
    {
        var request = new DeleteProvinceRequest();
        var command = request.ToApplicationRequest(provinceId);
        var response = await Mediator.Send(command);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response.Value);
    }
    #endregion
}