using AutoMapper;
using Domain;

namespace Application.Products
{
    public class ProductDtoMapperProfile : Profile
    {
        public ProductDtoMapperProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<Movie, MovieDetailDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Trivia, TriviaDto>();
        }
    }
}