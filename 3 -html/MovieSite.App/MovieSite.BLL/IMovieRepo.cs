using System.Collections.Generic;
using MovieSite.BLL;

namespace MovieSite.App.Repositories
{
    public interface IMovieRepo
    {
        void AddMovie(Movie movie);
        bool DeleteMovie(int id);
        Movie GetMovie(int id);
        IEnumerable<Movie> GetMovies();
    }
}