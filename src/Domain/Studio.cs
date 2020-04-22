using System.Collections.Generic;

namespace Domain
{
    public class Studio : ICustomer
    {
        private List<IProduct> products;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<IProduct> GetRentedProducts()
        {
            return null;
        }
    }
}