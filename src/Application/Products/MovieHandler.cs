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

        public async Task<List<Movie>> GetAll()
        {
            var movies = await context.Movies.ToListAsync();
            return movies;
        }

        public async Task<Movie> GetSingle(int id)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie != null) { return movie; }
            throw new Exception("Couldn't find studio with that id");
        }

        public async Task<Movie> Create(Movie product)
        {
            var movie = await context.Movies.AddAsync(product);

            // Save Changes
            var success = await context.SaveChangesAsync() > 0;
            
            if (success) { return movie.Entity; }
            
            throw new Exception("Problem saving changes!");
        }

        public async Task<Movie> Delete(int id)
        {
            var movie = await context.Movies.FindAsync(id);
            var result = context.Movies.Remove(movie);

            var success = await context.SaveChangesAsync() > 0;

            if (success) { return result.Entity; }
            throw new Exception("Problem saving changes!");
        }

        public async Task<Movie> Update(int id, Movie updatedMovie)
        {
            var oldMovie = await GetSingle(id);
            oldMovie.Title = updatedMovie.Title;
            oldMovie.Category = updatedMovie.Category;
            var result = context.Movies.Update(oldMovie);
            var success = await context.SaveChangesAsync() > 0;

            if (success) { return oldMovie; }
            throw new Exception("Problem saving changes!");
        }

        public async Task<Movie> AddReview(int movieId, Review review)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
            var authorExists = await context.Studios.FindAsync(review.AuthorId) != null;
            if(!authorExists) { throw new Exception("Author doesn't exist"); }
            movie.Reviews.Add(review);
            var success = await context.SaveChangesAsync() > 0;

            if (success) { return movie; }
            throw new Exception("Problem saving changes!");
        }

        public async Task<Movie> AddTrivia(int movieId, Trivia trivia)
        {
            var movie = await GetSingle(movieId);
            movie.Trivias.Add(trivia);

            context.Movies.Update(movie);

            var success = await context.SaveChangesAsync() > 0;
            if (success) { return movie; }
            throw new Exception("Could not update movie after adding tirvia");
        }

        public async Task<Movie> RemoveTrivia(int movieId, int triviaId)
        {
            var movie = await GetSingle(movieId);
            var triviaToRemove = movie.Trivias.FirstOrDefault(
                t => t.Id == triviaId);
            if (triviaToRemove == null) 
            {
                throw new Exception($"Trivia with id {triviaId} was not found");
            }
            movie.Trivias.Remove(triviaToRemove);

            context.Movies.Update(movie);

            var success = await context.SaveChangesAsync() > 0;
            if (success) { return movie; }
            throw new Exception("Could not update movie after deleting tirvia");
        }
    }
}