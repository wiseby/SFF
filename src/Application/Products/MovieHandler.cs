using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class MovieHandler : IProductHandler<MovieDto, MovieDetailDto>
    {
        private readonly DataContext context;
        private IMapper mapper;

        public MovieHandler(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<MovieDto>> GetAll()
        {
            var movies = await context.Movies.ToListAsync();
            return mapper.Map<List<MovieDto>>(movies);
        }

        public async Task<MovieDetailDto> GetSingle(int id)
        {
            var movie = await GetMovieFromDatabase(id);
            return mapper.Map<MovieDetailDto>(movie);
        }

        private async Task<Movie> GetMovieFromDatabase(int id)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie != null) { return movie; }
            throw new Exception("Couldn't find movie with that id");
        }

        public async Task<MovieDto> Create(MovieDetailDto product)
        {
            var movie = new Movie() 
            {
                Id = product.Id,
                Title = product.Title,
                Category = product.Category,
                Quantity = product.Quantity,
                Price = product.Price
            };
            var result = await context.Movies.AddAsync(movie);

            // Save Changes
            var success = await context.SaveChangesAsync() > 0;
            
            if (success) { return mapper.Map<MovieDto>(result.Entity); }
            
            throw new Exception("Problem saving changes!");
        }

        public async Task<MovieDto> Delete(int id)
        {
            // Find movie by id
            var movie = await context.Movies.FindAsync(id);

            // Delete movie
            var result = context.Movies.Remove(movie);

            var success = await context.SaveChangesAsync() > 0;

            // Return results
            if (success) { return mapper.Map<MovieDto>(result.Entity); }
            throw new Exception("Problem saving changes!");
        }

        public async Task<MovieDto> Update(int id, MovieDto updatedMovie)
        {
            var oldMovie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if(oldMovie == null) { throw new Exception($"Couldn't find movie with Id: {id}"); }
            
            oldMovie.Title = updatedMovie.Title;
            oldMovie.Category = updatedMovie.Category;

            var result = context.Movies.Update(oldMovie);
            var success = await context.SaveChangesAsync() > 0;

            if (success) { return mapper.Map<MovieDto>(oldMovie); }
            throw new Exception("Problem saving changes!");
        }

        public async Task<ReviewDto> AddReview(int movieId, ReviewDto review)
        {
            var newReview = new Review()
            {
                Rating = review.Rating,
                Comment = review.Comment,
                CreateDate = DateTime.Now,
                AuthorId = review.AuthorId  
            };

            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
            movie.Reviews.Add(newReview);
            // TODO:Is Review complete? Make validations for Customer != null
            var success = await context.SaveChangesAsync() > 0;

            if (success) { return mapper.Map<ReviewDto>(newReview); }
            throw new Exception("Problem saving changes!");
        }

        public async Task<TriviaDto> AddTrivia(int movieId, TriviaDto trivia)
        {
            var newTrivia = new Trivia()
            {
                Title = trivia.Title,
                Content = trivia.Content,
                CreateDate = DateTime.Now,
                MovieId = trivia.MovieId
            }; 
            var movie = await GetMovieFromDatabase(movieId);
            movie.Trivias.Add(newTrivia);

            context.Movies.Update(movie);

            var success = await context.SaveChangesAsync() > 0;
            if (success) { return mapper.Map<TriviaDto>(newTrivia); }
            throw new Exception("Could not update movie after adding tirvia");
        }

        public async Task<TriviaDto> RemoveTrivia(int movieId, int triviaId)
        {
            var movie = await GetMovieFromDatabase(movieId);
            var triviaToRemove = movie.Trivias.FirstOrDefault(
                t => t.Id == triviaId);
            if (triviaToRemove == null) 
            {
                throw new Exception($"Trivia with id {triviaId} was not found");
            }
            movie.Trivias.Remove(triviaToRemove);

            context.Movies.Update(movie);

            var success = await context.SaveChangesAsync() > 0;
            if (success) { return mapper.Map<TriviaDto>(triviaToRemove); }
            throw new Exception("Could not update movie after deleting tirvia");
        }
    }
}