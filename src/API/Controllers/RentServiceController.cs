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

        [HttpPost("rent")]
        public IActionResult RentMovie(int movieId, int studioId)
        {
            return Ok();
        }

        [HttpPost("return")]
        public IActionResult ReturnMovie(int movieId, int studioId)
        {
            return Ok();
        }
    }

}