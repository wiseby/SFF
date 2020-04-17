using System;

namespace Domain
{
    public class Movie : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int Licenses { get; set; }
        public float Price { get; set; }
    }
}
