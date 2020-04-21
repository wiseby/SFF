using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Application.RentService
{
    public class RentService : IRentService
    {
        private List<Invoice> invoices;
        private Dictionary<int, int> rentedMovies;
        private readonly IServiceScopeFactory scopeFactory;

        public RentService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
            rentedMovies = new Dictionary<int, int>();
            UpdateInvoices().Wait();
        }


        public async Task UpdateInvoices()
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider
                                   .GetRequiredService<DataContext>();
                invoices = await context
                                    .Invoices
                                    .Include(l => l.InvoiceLines)
                                    .ToListAsync();
            }
            UpdateRentedMovies();
        }


        private void UpdateRentedMovies()
        {
            foreach (var invoice in invoices)
            {
                foreach (var line in invoice.InvoiceLines)
                {
                    int id = line.ProductId;
                    if (rentedMovies.ContainsKey(id) && !line.Returned) { rentedMovies[id]++; }
                    else if(!line.Returned) { rentedMovies.Add(id, 1); }
                }
            }
        }


        public List<InvoiceDto> GetInvoicesByStudio(int studioId)
        {
            var invoiceDtos = new List<InvoiceDto>();
            var matchingInvoices = invoices.FindAll(i => i.StudioId == studioId);
            foreach (var invoice in matchingInvoices)
            {
                invoiceDtos.Add(new InvoiceDto().Convert(invoice));
            }
            return invoiceDtos;
        }


        public InvoiceDto GetSingelInvoiceByStudio(int studioId, int invoiceId)
        {
            var matchingInvoices = (from i in invoices
                                    where i.StudioId == studioId
                                    && i.Id == invoiceId
                                    select i).FirstOrDefault();

            if (matchingInvoices == null)
            {
                throw new Exception(
                    $"Order not found. InvoiceId: {invoiceId} | StudioId: {studioId}");
            }

            var dto = new InvoiceDto().Convert(matchingInvoices);
            return dto;
        }


        public async Task<InvoiceDto> Rent(int customerId, int[] movieId)
        {
            Studio customer;
            List<Movie> movies = new List<Movie>();

            // Retrieve data:
            using(var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                customer = context.Studios.FirstOrDefault(s => s.Id == customerId);
                
                // Search movie and check if it's available
                foreach(var id in movieId)
                {
                    var movie = context.Movies.FirstOrDefault(m => m.Id == id);
                    if(movie != null) { movies.Add(movie); }
                }
            }

            if(movies.Count == 0) 
            {
                throw new Exception("Selected movies where not found");
            }
            if(customer == null) 
            { 
                throw new Exception($"Customer with id: {customerId} was not found"); 
            }

            var invoice = new Invoice();
            invoice.StudioId = customer.Id;

            foreach (var movie in movies)
            {
                var movieAvailable = !(rentedMovies.ContainsKey(movie.Id) && 
                movie.Licenses - rentedMovies[movie.Id] < 1 ||
                movie.Licenses < 1);

                if(movieAvailable)
                {
                    invoice.InvoiceLines.Add(new InvoiceLine() { 
                        ProductId = movie.Id,
                        CreateDate = DateTime.Now,
                        PurchasePrice = movie.Price
                        });
                }

                else { throw new Exception($"This movie is not available: {movie.Title}"); }
            }

            var result = await SaveInvoiceToDatabase(invoice);
            await UpdateInvoices();
            return new InvoiceDto().Convert(invoice);
        }


        private async Task<bool> SaveInvoiceToDatabase(Invoice invoice)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider
                                   .GetRequiredService<DataContext>();
                context.Invoices.Add(invoice);
                var success = await context.SaveChangesAsync() > 0;
                return success;
            }
        }       


        public async Task<List<InvoiceLineDto>> Return(int studioId, int[] movieId)
        {
            var dtos = new List<InvoiceLineDto>();
            // Find all Invoices for Studio
            var moviesToReturn =   from i in invoices
                                    where i.StudioId == studioId
                                    from l in i.InvoiceLines
                                    from m in movieId
                                    where l.ProductId == m
                                    select l;

            // For every Invoices InvoiceLine matching movieId Returned bool is true.
            foreach (var invoiceLine in moviesToReturn)
            {
                invoiceLine.Returned = true;
                dtos.Add(new InvoiceLineDto().Convert(invoiceLine));
            }

            // Update Invoices
            var success = await UpdateInvoiceInDatabase(invoices);

            // Return Invoices that have been affected
            if(success) { return dtos; }

            throw new Exception("Failed to update Invoices after return operation");
        }

        private async Task<bool> UpdateInvoiceInDatabase(List<Invoice> invoices)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider
                                   .GetRequiredService<DataContext>();
                context.Invoices.UpdateRange(invoices);
                var success = await context.SaveChangesAsync() > 0;
                return success;
            }
        }       
    }
}