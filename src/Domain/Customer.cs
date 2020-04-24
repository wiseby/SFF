using System.Collections.Generic;

namespace Domain
{
    public abstract class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Product> Products { get; set; }
    }
}