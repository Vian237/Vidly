using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
        }
    }
}
