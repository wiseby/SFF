using System.Collections.Generic;

namespace Application.RentService
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int StudioId { get; set; }
        public List<InvoiceLineDto> InvoiceLineDtos { get; set; }
    }
}