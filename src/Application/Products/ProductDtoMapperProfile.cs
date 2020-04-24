using AutoMapper;
using Domain;

namespace Application.Products
{
    public class ProductDtoMapperProfile : Profile
    {
        public ProductDtoMapperProfile()
        {
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie, MovieDetailDto>();
            CreateMap<MovieDetailDto, Movie>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Trivia, TriviaDto>();
        }
    }
}