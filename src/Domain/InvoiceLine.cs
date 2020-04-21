using System;

namespace Domain
{
    public class InvoiceLine
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int ProductId { get; set; }
        public DateTime CreateDate { get; set; }
        public float PurchasePrice { get; set; }
        public bool Returned { get; set; }
    }
}