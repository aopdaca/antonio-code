using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.App.Models
{
    // sometimes when existing model classes are not the right structure for a view
    // we make a "view model" which will be coupled to the needs of that view
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Release Year")]
        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }

        public string Genre { get; set; }
    }
}
