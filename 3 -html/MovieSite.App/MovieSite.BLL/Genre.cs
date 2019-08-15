using System.Collections.Generic;

namespace MovieSite.BLL
{
    public class Genre
    {
        public string Name { get; set; }

        public ISet<Movie> Movies { get; set; }
    }
}