using Microsoft.EntityFrameworkCore;
using Domain;
using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Movie> Movies { get; set;}
        public DbSet<Studio> Studios { get; set;}
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
