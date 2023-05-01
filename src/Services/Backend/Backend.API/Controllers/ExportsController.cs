using Azure;
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
        public IActionResult Export([FromBody] ExportExcelModel request)
        {
            if (request == null)
                return BadRequest();
            var service = new ExportExcelService();
            var document = service.GenerateExcel(request);
            var xlsContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(document!, xlsContentType, $"Reporte-{DateTime.Now.Ticks}.xlsx");
            
        }
    }
}
