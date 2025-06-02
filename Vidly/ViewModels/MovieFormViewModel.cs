using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Movie Name is required.")]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Movie Release date is required.")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Required(ErrorMessage = "Number in stock is required.")]
        [Range(1, 20, ErrorMessage = "Number in stock must be between 1 and 20.")]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is required.")]
        public byte? GenreId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}
