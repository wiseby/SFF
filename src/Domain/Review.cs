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
        public string Comment
        {
            get { return comment; }
            set
            {
                if (value.Length > 40) { comment = value; }
                else
                {
                    throw new Exception(
                        "Comment needs to be longer than 40 characters");
                }
            }
        }

        private DateTime createDate;
        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = DateTime.Now; }
        }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int AuthorId { get; set; }
        public Studio Author { get; set; }
    }
}