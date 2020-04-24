using System.Collections.Generic;

namespace Domain
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}