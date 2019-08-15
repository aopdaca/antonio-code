using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSite.Data
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }

        // navigation property
        public Genre Genre { get; set; }
    }
}
