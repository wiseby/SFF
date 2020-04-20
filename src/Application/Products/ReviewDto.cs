using System;
using Domain;

namespace Application.Products
{
    public class ReviewDto
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }

        public ReviewDto()
        {
            
        }

        public ReviewDto Convert(Review review)
        {
            Rating = review.Rating;
            Comment = review.Comment;
            Author = review.Author.Name;
            CreateDate = review.CreateDate;
            return this;
        }
    }
}