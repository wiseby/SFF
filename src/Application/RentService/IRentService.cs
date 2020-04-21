using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application.RentService
{
    public interface IRentService
    {
        public Task UpdateInvoices();
        public Task<InvoiceDto> Rent(int customerId, int[] productId);
        public Task<List<InvoiceLineDto>> Return(int customerId, int[] productId);
        public List<InvoiceDto> GetInvoicesByStudio(int studioId);
        public InvoiceDto GetSingelInvoiceByStudio(int studioId, int orderId);
        public InvoiceLabelDto GetLabelForInvoice(int invoiceId);
    }
}