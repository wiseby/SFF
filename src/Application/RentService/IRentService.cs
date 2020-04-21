using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application.RentService
{
    public interface IRentService
    {
        public void Initialize();
        public Task<InvoiceDto> Rent(Studio customer, Movie product);
        public Task<InvoiceDto> Return(Studio customer, Movie product);
        public Task<List<InvoiceDto>> GetInvoicesByStudio(int studioId);
        public Task<InvoiceDto> GetSingelInvoiceByStudio(int studioId, int orderId);
    }
}