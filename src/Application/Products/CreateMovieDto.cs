namespace Application.Products
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}