using Microsoft.AspNetCore.Mvc;
using Domain;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/V1.0/[controller]")]
    [ApiController]
    public class StudiosController : ControllerBase
    {
        public StudiosController()
        {
            
        }

        [HttpGet]
        public ActionResult<List<Studio>> GetAllStudios()
        {
            return Ok();
        }

        [HttpGet("/{id}")]
        public ActionResult<Studio> GetStudioById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult<Studio> CreateStudio()
        {
            return Ok();
        }

        [HttpPut("/{id}")]
        public ActionResult<Studio> ModifyStudio(int id)
        {
            return Ok();
        }

        [HttpDelete("/{id}")]
        public ActionResult<Studio> RemoveStudio(int id)
        {
            return Ok();
        }
    }
}