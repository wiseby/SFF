using System.Collections.Generic;

namespace Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public int StudioId { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; }

        public Invoice()
        {
            InvoiceLines = new List<InvoiceLine>();
        }
    }
}