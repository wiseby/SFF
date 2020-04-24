using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain;
using Application.Products;
using System.Threading.Tasks;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/V1.0/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IProductHandler<MovieDto, MovieDetailDto> handler;
        public MoviesController(IProductHandler<MovieDto, MovieDetailDto> handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDto>>> GetMovies()
        {
            var movies = await handler.GetAll();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDetailDto>> GetMovieById(int id)
        {
            var movie = await handler.GetSingle(id);
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDto>> CreateMovie(MovieDetailDto movie)
        {
            var newMovie = await handler.Create(movie);
            return Ok(movie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieDto>> ModifiyMovie(int id, MovieDto movie)
        {
            var result = await handler.Update(id, movie);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieDto>> DeleteMovie(int id)
        {
            var movie = await handler.Delete(id);
            return Ok(movie);
        }

        [HttpPost]
        [Route("{movieId}/reviews/")]
        public async Task<ActionResult<Review>> CreateReview(int movieId, ReviewDto review)
        {
            var result = await handler.AddReview(movieId, review);
            return Ok(result);
        }

        [HttpPost]
        [Route("trivias/")]
        public async Task<ActionResult<MovieDto>> CreateTrivia(TriviaDto trivia)
        {
            var result = await handler.AddTrivia(trivia);
            return Ok(result);
        }
    }
}