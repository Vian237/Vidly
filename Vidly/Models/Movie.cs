using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie Name is required.")]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Movie Release date is required.")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        [Required(ErrorMessage = "Date added is required.")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Required(ErrorMessage = "Number in stock is required.")]
        [Range(1, 20, ErrorMessage = "Number in stock must be between 1 and 20.")]
        public int NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is required.")]
        public byte GenreId { get; set; }

        // Navigation Property
        public Genre Genre { get; set; }
    }
}
