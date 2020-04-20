using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application.Products
{
    public interface IProductHandler<T>
    {
        public Task<List<ProductDto>> GetAll();
        public Task<ProductDto> GetSingle(int id);
        public Task<ProductDto> Create(T product);
        public Task<ProductDto> Delete(int id);
        public Task<ProductDto> Update(int id, T product);
        public Task<ReviewDto> AddReview(int productId, Review review);
        public Task<TriviaDto> AddTrivia(Trivia trivia);
        public Task<TriviaDto> RemoveTrivia(int movieId, int triviaId);
    }
}