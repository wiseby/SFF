using System.Threading.Tasks;
using Application.RentService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/V1.0/rentservice")]
    [ApiController]
    public class RentServiceController : ControllerBase
    {
        private readonly IRentService service;

        public RentServiceController(IRentService service)
        {
            this.service = service;
            
        }

        // [HttpGet]
        // [Route("orders")]
        // public IActionResult GetStudioInvoices(
        //     [FromQuery] int studioId)
        // {
        //     var result = service.GetInvoicesByStudio(studioId);
        //     return Ok(result);
        // }


        [HttpGet]
        [Route("orders")]
        public IActionResult GetStudioInvoiceFromId(
            [FromQuery(Name = "studioId")] int studioId, [FromQuery(Name = "invoiceId")] int invoiceId)
        {
            if(invoiceId == 0) { return Ok(service.GetInvoicesByStudio(studioId)); }
            else { return Ok(service.GetSingelInvoiceByStudio(studioId, invoiceId)); }
        }


        // [HttpGet]
        // [Route("orders")]
        // public IActionResult GetStudioInvoices(
        //     [FromQuery] int studioId, [FromQuery] int invoiceId)
        // {
        //     var result = service.GetSingelInvoiceByStudio(studioId, invoiceId);
        //     return Ok(result);
        // }


        [HttpPost("rent")]
        public async Task<IActionResult> RentMovie([FromBody] RentRequest request)
        {
            var result = await service.Rent(request.StudioId, request.MovieId);
            return Ok(result);
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnMovie([FromBody] ReturnRequest request)
        {
            var result = await service.Return(request.StudioId, request.MovieId);
            return Ok(result);
        }
    }

}