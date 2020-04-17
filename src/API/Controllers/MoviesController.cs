using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain;
using Application.Products;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/V1.0/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IProductHandler<Movie> handler;
        public MoviesController(IProductHandler<Movie> handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var movies = await handler.GetAll();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            var movie = await handler.GetSingle(id);
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
        {
            var newMovie = await handler.Create(movie);
            return Ok(movie);
        }

        [HttpPut("{id}")]
        public ActionResult<Movie> ModifiyMovie(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movie = await handler.Delete(id);
            return Ok(movie);
        }
    }
}