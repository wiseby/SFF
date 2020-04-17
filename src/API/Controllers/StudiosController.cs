using Microsoft.AspNetCore.Mvc;
using Domain;
using System.Collections.Generic;
using Persistence;

namespace API.Controllers
{
    [Route("api/V1.0/studios")]
    [ApiController]
    public class StudiosController : ControllerBase
    {
        private DataContext context;

        public StudiosController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Studio>> GetAllStudios()
        {
            
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<Studio> GetStudioById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult<Studio> CreateStudio()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Studio> ModifyStudio(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Studio> RemoveStudio(int id)
        {
            return Ok();
        }
    }
}