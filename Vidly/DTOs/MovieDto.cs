using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Movie Release date is required.")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Date added is required.")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Number in stock is required.")]
        [Range(1, 20, ErrorMessage = "Number in stock must be between 1 and 20.")]
        public int NumberInStock { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}
