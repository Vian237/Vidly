using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
        //Get: Movies/Random
        public IActionResult Random()
        {           
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            //return View(movie);
            //return Content("Hello Vianney");
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }

        public IActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies
        //public IActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content($"pageIndex={pageIndex} & sortBy={sortBy}");
        //}

        [Route("movies/released/{year}/{month:range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "StarWars" },
                new Movie {Id = 2, Name = "Zombie" }
            };
        }
    }
}
