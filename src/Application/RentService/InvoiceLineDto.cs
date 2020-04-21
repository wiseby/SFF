using System;
using Domain;

namespace Application.RentService
{
    public class InvoiceLineDto
    {
        public int Id { get; set; }
        public Movie Product { get; set; }
        public DateTime CreateDate { get; set; }
        public float PurchasePrice { get; set; }
    }
}