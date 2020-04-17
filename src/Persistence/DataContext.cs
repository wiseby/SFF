using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Movie> Movies { get; set;}
        public DbSet<Studio> Studios { get; set;}
    }
}
