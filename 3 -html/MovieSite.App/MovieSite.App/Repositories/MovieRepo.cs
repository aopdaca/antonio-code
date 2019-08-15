using MovieSite.BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.App.Repositories
{
    public class MovieRepo : IMovieRepo
    {
        private readonly List<Movie> _movies;

        public MovieRepo(List<Movie> movies)
        {
            _movies = movies ?? throw new ArgumentNullException(nameof(movies));
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _movies.ToList();
        }

        public Movie GetMovie(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public bool DeleteMovie(int id)
        {
            if (GetMovie(id) is Movie movie)
            {
                _movies.Remove(movie);
                return true;
            }
            return false;
        }

        public void AddMovie(Movie movie)
        {
            if (_movies.Any(m => m.Title == movie.Title && m.ReleaseYear == movie.ReleaseYear))
            {
                throw new ArgumentException("Movie with same title and year already exists", nameof(movie));
            }

            if (_movies.Count == 0)
            {
                movie.Id = 1;
            }
            else
            {
                movie.Id = _movies.Max(m => m.Id) + 1;
            }
            _movies.Add(movie);
        }
    }
}
