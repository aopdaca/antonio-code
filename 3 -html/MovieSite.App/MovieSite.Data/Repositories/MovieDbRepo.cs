using MovieSite.App.Repositories;
using MovieSite.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSite.Data.Repositories
{
    public class MovieDbRepo : IMovieRepo
    {
        public void AddMovie(BLL.Movie movie)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public BLL.Movie GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BLL.Movie> GetMovies()
        {
            throw new NotImplementedException();
        }
    }
}
