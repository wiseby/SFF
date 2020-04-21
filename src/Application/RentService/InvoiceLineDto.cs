using System;
using Domain;

namespace Application.RentService
{
    public class InvoiceLineDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime CreateDate { get; set; }
        public float PurchasePrice { get; set; }
        public bool Returned { get; set; }


        public InvoiceLineDto Convert(InvoiceLine line)
        {
            Id = line.Id;
            ProductId = line.ProductId;
            CreateDate = line.CreateDate;
            PurchasePrice = line.PurchasePrice;
            Returned = line.Returned;
            return this;
        }
    }

}