using System.Collections.Generic;

namespace Domain
{
    public interface ICustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<IProduct> GetRentedProducts();
    }
}