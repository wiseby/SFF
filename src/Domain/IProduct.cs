using System.Collections.Generic;

namespace Domain
{
    public interface IProduct
    {
        public int Id { get; set; }
         public string Name { get; set; }
         public int Quantity { get; set; }
         public int Licenses { get; set; }
         public float Price { get; set; }
         public int ReviewId { get; set; }
         public List<Review> Reviews { get; set; }
         public int TriviaId { get; set; }
         public List<Trivia> Trivias { get; set; }
    }
}