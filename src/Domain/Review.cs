using System;

namespace Domain
{
    public class Review
    {
        public int Id { get; set; }
        private int rating;
        public int Rating
        {
            get { return rating; }
            set
            {
                if (value <= 10 || value > 0) { rating = value; }
                else { throw new Exception("Rating not in valid range"); }
            }
        }

        private string comment;
        public string Comment { 
                get { return comment; } 
                set 
                { 
                    if (value.Length > 40) { comment = value; }
                    else { 
                        throw new Exception(
                            "Comment needs to be longer than 40 characters"); 
                        }
                } 
            }
        public DateTime CreateDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}