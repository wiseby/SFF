using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class MovieHandler : IProductHandler<Movie>
    {
        private List<Movie> products;
        private readonly DataContext context;

        public MovieHandler(DataContext context)
        {
            products = new List<Movie>();
            this.context = context;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var movies = await context.Movies
                .Include(a => a.Reviews)
                .Include(a => a.Trivias)
                .ToListAsync();

            var models = new List<ProductDto>();
            foreach (var movie in movies)
            {
                var dto = new ProductDto();
                models.Add(dto.Convert(movie));
            }
            return models;
        }

        public async Task<ProductDto> GetSingle(int id)
        {
            var movie = await GetMovieById(id);
            var dto = new ProductDto();
            if (movie != null) { return dto.Convert(movie); }
            throw new Exception("Couldn't find movie with that id");
        }

        public async Task<ProductDto> Create(Movie product)
        {
            var movie = await context.Movies.AddAsync(product);
            var success = await context.SaveChangesAsync() > 0;

            var dto = new ProductDto();
            
            if (success) { return dto.Convert(movie.Entity); }
            
            throw new Exception("Problem saving changes!");
        }

        public async Task<ProductDto> Delete(int id)
        {
            var movie = await GetMovieById(id);
            var result = context.Movies.Remove(movie);

            var success = await context.SaveChangesAsync() > 0;
            var dto = new ProductDto();

            if (success) { return dto.Convert(result.Entity); }
            throw new Exception("Problem saving changes!");
        }

        public async Task<ProductDto> Update(int id, Movie updatedMovie)
        {
            var changingMovie = await GetMovieById(id);
            changingMovie = updatedMovie;
            var result = context.Movies.Update(changingMovie);
            var success = await context.SaveChangesAsync() > 0;
            var dto = new ProductDto();
            if (success) { return dto.Convert(changingMovie); }
            throw new Exception("Problem saving changes!");
        }

        public async Task<ReviewDto> AddReview(int movieId, Review review)
        {
            var movie = await GetMovieById(movieId);
            var authorExists = await context.Studios.FindAsync(review.AuthorId) != null;
            if(!authorExists) { throw new Exception("Author doesn't exist"); }
            movie.Reviews.Add(review);
            var success = await context.SaveChangesAsync() > 0;

            var dto = new ReviewDto();
            if (success) { return dto.Convert(review); }
            throw new Exception("Problem saving changes!");
        }

        public async Task<TriviaDto> AddTrivia(Trivia trivia)
        {
            var movie = await GetMovieById(trivia.MovieId);
            movie.Trivias.Add(trivia);
            context.Movies.Update(movie);
            var converter = new TriviaDto();
            var success = await context.SaveChangesAsync() > 0;
            if (success) { return converter.Convert(trivia); }
            throw new Exception("Could not update movie after adding tirvia");
        }

        public async Task<TriviaDto> RemoveTrivia(int movieId, int triviaId)
        {
            var movie = await context.Movies
                                      .Include(t => t.Trivias)
                                      .FirstOrDefaultAsync(m => m.Id == movieId);
            
            Trivia matchingTrivia = null;
            foreach(var trivia in movie.Trivias)
            {
                if (trivia.Id == triviaId) 
                { 
                    matchingTrivia = trivia; 
                    break;
                }
            }
            if (matchingTrivia == null) 
            {
                throw new Exception(
                    $"Trivia with id {triviaId} was not found");
            }
            movie.Trivias.Remove(matchingTrivia);
            context.Movies.Update(movie);
            var model = new TriviaDto().Convert(matchingTrivia);
            var success = await context.SaveChangesAsync() > 0;
            if (success) { return model; }
            throw new Exception("Could not update movie after deleting tirvia");
        }

        private async Task<Movie> GetMovieById(int id)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie != null) { return movie; }
            throw new Exception("Couldn't find movie with that id");
        }
    }
}