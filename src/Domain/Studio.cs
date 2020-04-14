using System.Collections.Generic;

namespace Domain
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        private List<Movie> movies;
    }
}