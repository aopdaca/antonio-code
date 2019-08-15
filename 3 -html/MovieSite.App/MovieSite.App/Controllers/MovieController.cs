using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieSite.App.Models;
using MovieSite.App.Repositories;
using MovieSite.BLL;

namespace MovieSite.App.Controllers
{
    public class MovieController : Controller
    {
        // dependency injection is a design pattern / practice
        // if a class has some dependency on another class
        //     (e.g., this controller needs a MovieRepo to really do its job)
        // then it should NOT create that object itself.
        // it should receive it in the constructor.

            // Startup.ConfigureServices is responsible for how to get the dependency
        private readonly IMovieRepo _movieRepo;

        public MovieController(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo ?? throw new ArgumentNullException(nameof(movieRepo));
        }

        // in a controller, all the public methods are "action methods" by default
        // (we have a [NonAction] attribute for any helper methods)


        // action method to list all the movies in a table.
        public IActionResult Index()
        {
            IEnumerable<MovieViewModel> viewModel = _movieRepo.GetMovies().Select(m => new MovieViewModel
            {
                Id = m.Id,
                Title = m.Title,
                ReleaseYear = m.ReleaseYear,
                Genre = m.Genre?.Name
            });

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        // to receive the form data back...
        // an overload of the same action method with some parameter and [HttpPost] attribute
        [HttpPost] // the other method will be for GET requests, this one will be for POST (the form data will come back as a POST)
        public IActionResult Create(MovieViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // there was a server-side validation error - return the user a new
                // form with what he put in.
                return View(viewModel);
            }

            // model binding:
            //    when action methods have parameters, the framework tries to fill them with data
            //    converting types and such, based on the property names matching the form field names.

            // server-side validation
                // in the action method where you receive form data (or any data, e.g. query string params)
                // you need to validate that with logic here.
                // ASP.NET helps us with this with DataAnnotations 
                //    and ModelState object, with model binding

            // client-side validation
                // when possible, the form page itself, in front of the user, should stop him
                // from entering bad data (like with HTML validation attributes, or JS)
                // ASP.NET helps us with this with DataAnnotations
                //    and jQuery Unobtrusive library and HTML validation attrs
                //    (with the help of tag helpers)

            var movie = new Movie
            {
                Title = viewModel.Title,
                ReleaseYear = viewModel.ReleaseYear
            };

            try
            {
                _movieRepo.AddMovie(movie);
            }
            catch (ArgumentException ex)
            {
                //ModelState.AddModelError("Title", "title error");

                // empty string for "key" means, it's overall model error
                ModelState.AddModelError("", ex.Message);
                return View(viewModel);
            }

            // if we did "return View", the URL bar would still say "Create"
            //return View("Index", _movieRepo.GetMovies.......)
            return RedirectToAction(nameof(Index)); // tell the browser to make a new GET request
            // to the Index action.
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            if (_movieRepo.GetMovie(id) is Movie movie)
            {
                var viewModel = new MovieViewModel
                {
                    Title = movie.Title,
                    ReleaseYear = movie.ReleaseYear,
                    Genre = movie.Genre?.Name
                };
                return View(viewModel);
            }
            return View("Error", new ErrorViewModel { Message = "Resource not found." });
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                if (_movieRepo.GetMovie(id) is Movie movie)
                {
                    movie.Title = viewModel.Title;
                    movie.ReleaseYear = viewModel.ReleaseYear;
                    // (edit genre left unimplemented)

                    return RedirectToAction(nameof(Index));
                }
                return View("Error", new ErrorViewModel { Message = "Resource not found." });
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            if (_movieRepo.GetMovie(id) is Movie movie)
            {
                var viewModel = new MovieViewModel
                {
                    Title = movie.Title,
                    ReleaseYear = movie.ReleaseYear,
                    Genre = movie.Genre?.Name
                };

                return View(viewModel);
            }
            // show some error view
            return View("Error", new ErrorViewModel { Message = "Resource not found." });
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var success = _movieRepo.DeleteMovie(id);

                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error", new ErrorViewModel { Message = "Resource not found." });
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
        }
    }
}