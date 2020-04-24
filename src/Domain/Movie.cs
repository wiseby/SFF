using System;
using System.Collections.Generic;

namespace Domain
{
    public class Movie : Product
    {
        public string Category { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Trivia> Trivias { get; set; }
    }
}
