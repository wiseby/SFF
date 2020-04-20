using System;
using System.Collections.Generic;
using Domain;

namespace Application.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ReviewDto> Reviews { get; set; }
        public List<TriviaDto> Trivias { get; set; }

        public ProductDto()
        {
            Reviews = new List<ReviewDto>();
            Trivias = new List<TriviaDto>();            
        }

        public ProductDto Convert(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            foreach(var review in movie.Reviews)
            {
                Reviews.Add(new ReviewDto().Convert(review));
            }
            foreach(var trivia in movie.Trivias)
            {
                Trivias.Add(new TriviaDto().Convert(trivia));
            }
            return this;
        }
    }
}