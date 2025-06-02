using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(IMapper mapper)
        {
            _context = new AppDbContext();
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _context.Movies.ToList();
            var movieDtos = _mapper.Map<IEnumerable<MovieDto>>(movies);
            return Ok(movieDtos);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            var movieDto = _mapper.Map<MovieDto>(movie);
            return Ok(movieDto);
        }

        // POST: api/Movies
        [HttpPost]
        public IActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movie = _mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            // Set the ID of the created movie
            movieDto.Id = movie.Id;

            // Return the created movie with a 201 Created response
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movieDto);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (id != movieDto.Id)
                return BadRequest("Movie ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Find the movie by ID
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            // Map the updated properties from the DTO to the entity
            _mapper.Map(movieDto, movie);
            _context.SaveChanges();

            return NoContent(); // Return 204 No Content on successful update
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            // Remove the movie from the context
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}
