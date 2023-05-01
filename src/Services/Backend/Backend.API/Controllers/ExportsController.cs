using Azure;
using Backend.API.DTOs.Requests.CaseRequests;
using backend.Infrastructure.Services;
using Backend.API.DTOs.Requests.UserRequests;
using Backend.Domain.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{

    public class ExportsController : BaseController
    {
        public ExportsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("export")]
        public async Task<IActionResult> Export([FromBody] ReadCasesToExcelRequest request)
        {
            var query = request.ToApplicationRequest();
            var response = await Mediator.Send(query);
            if (!response.IsSuccess)
            {
                return BadRequest();
            }
            var xlsContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(response.Value!, xlsContentType, $"Reporte-{DateTime.Now.Ticks}.xlsx");
            
        }
    }
}
