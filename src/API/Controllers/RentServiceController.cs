using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/V1.0/[controller]")]
    [ApiController]
    public class RentServiceController : ControllerBase
    {
        public RentServiceController()
        {
            
        }

        [HttpPost("/rent")]
        public IActionResult RentMovie(int movieId, int studioId)
        {
            return Ok();
        }

        [HttpPost("/return")]
        public IActionResult ReturnMovie(int movieId, int studioId)
        {
            return Ok();
        }
    }

}