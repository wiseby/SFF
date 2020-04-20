using System;
using Domain;

namespace Application.Products
{
    public class TriviaDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }

        public TriviaDto()
        {
            
        }

        public TriviaDto Convert(Trivia trivia)
        {
            Id = trivia.Id;
            Title = trivia.Title;
            Content = trivia.Content;
            CreateDate = trivia.CreateDate;

            return this;
        }
    }
}