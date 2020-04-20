using System.Collections.Generic;

namespace Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public int StudioId { get; set; }
        public Studio Studio { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; }
    }
}