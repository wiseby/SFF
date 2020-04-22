using System.Collections.Generic;

namespace Domain
{
    public interface IProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Trivia> Trivias { get; set; }
    }
}