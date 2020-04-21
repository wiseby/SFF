using Microsoft.AspNetCore.Mvc;
using Domain;
using System.Collections.Generic;
using Application.Customers;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/V1.0/studios")]
    [ApiController]
    public class StudiosController : ControllerBase
    {
        private readonly ICustomerHandler<Studio> handler;

        public StudiosController(ICustomerHandler<Studio> handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public async Task<ActionResult<List<Studio>>> GetAllStudios()
        {
            var studios = await handler.GetAll();
            return Ok(studios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Studio>> GetStudioById(int id)
        {
            var studio = await handler.GetSingle(id);
            return Ok(studio);
        }

        [HttpPost]
        public async Task<ActionResult<Studio>> CreateStudio(Studio studio)
        {
            var result = await handler.Create(studio);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Studio>> ModifyStudio(int id, Studio studio)
        {
            var result = await handler.Update(id, studio);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Studio>> RemoveStudio(int id)
        {
            var result = await handler.Delete(id);
            return Ok(result);
        }
    }
}