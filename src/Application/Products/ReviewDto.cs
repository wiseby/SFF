namespace Application.Products
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int AuthorId { get; set; }
        public int MovieId { get; set; }
    }
}