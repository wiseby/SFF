using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Persistence;

namespace Application.RentService
{
    public class RentService : IRentService
    {
        private List<Invoice> invoices;
        private readonly DataContext context;
        public RentService(DataContext context)
        {
            this.context = context;
            Initialize();
        }
        public async void Initialize()
        {
            invoices = await context.Invoices.ToListAsync();
        }
        public Task<List<InvoiceDto>> GetOrdersByStudio(int studioId)
        {
            throw new System.NotImplementedException();
        }

        public Task<InvoiceDto> GetSingelOrderByStudio(int studioId, int orderId)
        {
            throw new System.NotImplementedException();
        }

        public Task<InvoiceDto> Rent(Studio customer, Movie product)
        {
            throw new System.NotImplementedException();
        }

        public Task<InvoiceDto> Return(Studio customer, Movie product)
        {
            throw new System.NotImplementedException();
        }
    }
}