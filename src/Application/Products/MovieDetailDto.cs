using Domain;

namespace Application.Products
{
    public class MovieDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}