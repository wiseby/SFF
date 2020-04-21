using System.Collections.Generic;
using Domain;

namespace Application.RentService
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int StudioId { get; set; }
        public List<InvoiceLineDto> InvoiceLineDtos { get; set; }

        public InvoiceDto Convert(Invoice invoice)
        {
            Id = invoice.Id;
            StudioId = invoice.StudioId;
            InvoiceLineDtos = new List<InvoiceLineDto>();
            foreach (var line in invoice.InvoiceLines)
            {
                InvoiceLineDtos.Add(new InvoiceLineDto().Convert(line));
            }
            return this;
        }
    }
}