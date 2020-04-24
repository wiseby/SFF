using System.Collections.Generic;
using Application.Products;

namespace Application.Customers
{
    public class StudioDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}