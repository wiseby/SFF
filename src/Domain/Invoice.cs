using System;

namespace Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime CreateDate { get; set; }
    }
}