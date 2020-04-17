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
            var movie = await context.Movies.FindAsync(id);
            return movie;
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
            // Find movie by id
            var movie = await context.Movies.FindAsync(id);

            // Delete movie
            var result = context.Movies.Remove(movie);

            var success = await context.SaveChangesAsync() > 0;

            // Return results
            if (success) { return result.Entity; }
            throw new Exception("Problem saving changes!");
        }

        public async Task<Movie> Update(int id, Movie updatedMovie)
        {
            var oldMovie = await GetSingle(id);
            oldMovie.Name = updatedMovie.Name;
            oldMovie.Category = updatedMovie.Category;
            var result = context.Movies.Update(oldMovie);
            var success = await context.SaveChangesAsync() > 0;

            if (success) { return oldMovie; }
            throw new Exception("Problem saving changes!");
        }
    }
}