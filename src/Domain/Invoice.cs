using System;

namespace Domain
{
    public class Invoice
    {
        public int ProductId { get; set; }
        public IProduct Product { get; set; }
        public DateTime CreateDate { get; set; }
    }
}