using System.Collections.Generic;

namespace MovieSite.Data
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // collection navigation property (inverse of Movie.Genre)
        public ISet<Movie> Movies { get; set; }
    }
}