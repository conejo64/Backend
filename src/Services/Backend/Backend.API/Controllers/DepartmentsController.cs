using Backend.API.DTOs.Requests.DepartmentRequests;
using Backend.Application.DTOs.Responses.DepartmentResponses;
using Backend.Application.Queries.DepartmentQueries;

namespace Backend.API.Controllers;

public class DepartmentsController : BaseController
{
    #region Contructor & Properties

    public DepartmentsController(IMediator mediator) : base(mediator)
    {
    }

    #endregion

    [HttpGet]
    [JwtAuthorize(JwtScope.Manager)]    
    //[AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(IReadOnlyCollection<DepartmentResponse>))]
    [Route("")]
    public async Task<IActionResult> ReadDepartments([FromQuery] ReadDepartmentsRequest request)
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
    [Produces(typeof(IReadOnlyCollection<DepartmentResponse>))]
    [Route("all")]
    public async Task<IActionResult> ReadAllDepartments()
    {
        var query = new ReadAllDepartmentsQuery();

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
    [Produces(typeof(DepartmentResponse))]
    [Route("{departmentId:guid}")]
    public async Task<IActionResult> ReadDepartment(Guid departmentId)
    {
        var request = new ReadDepartmentRequest(departmentId);
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
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request)
    {
        var command = request.ToApplicationRequest();

        var response = await Mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(ReadDepartment), new { Department = response.Value }, response.Value);
    }

    [HttpPut]
    [JwtAuthorize(JwtScope.Manager)]
    //[AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Route("{departmentId:guid}")]
    public async Task<IActionResult> UpdateDepartment(Guid departmentId,
        [FromBody] UpdateDepartmentRequest request)
    {
        var command = request.ToApplicationRequest(departmentId);

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
    [Route("{departmentId:guid}")]
    public async Task<IActionResult> DeleteDepartment(Guid departmentId)
    {
        var request = new DeleteDepartmentRequest();
        var command = request.ToApplicationRequest(departmentId);
        var response = await Mediator.Send(command);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response.Value);
    }
    #endregion
}