using Microsoft.AspNetCore.Mvc;
using Application;
using System.Collections.Generic;
using Domain;

namespace API.Controllers
{
    [Route("api/V1.0/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesController()
        {
        
        }

        [HttpGet]
        public ActionResult<List<Movie>> GetMovies()
        {
            return Ok();
        }

        [HttpGet("/{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult<Movie> CreateMovie(Movie movie)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Movie> ModifiyMovie(int id)
        {
            return Ok();
        }
    }
}