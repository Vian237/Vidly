using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //Get: Movies/Random
        public IActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek!"
            };
            return View(movie);
            //return Content("Hello Vianney");
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }

        public IActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content($"pageIndex={pageIndex} & sortBy={sortBy}");
        }

        [Route("movies/released/{year}/{month:range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }
    }
}
