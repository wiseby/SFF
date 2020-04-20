using System;
using System.Collections.Generic;

namespace Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public int Licenses { get; set; }
        public float Price { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Trivia> Trivias { get; set; } = new List<Trivia>();
    }
}
