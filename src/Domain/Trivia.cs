using System;

namespace Domain
{
    public class Trivia
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}