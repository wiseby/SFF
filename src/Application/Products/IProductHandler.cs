using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Products
{
    public interface IProductHandler<T, U>
    {
        public Task<List<T>> GetAll();
        public Task<U> GetSingle(int id);
        public Task<T> Create(U product);
        public Task<T> Delete(int id);
        public Task<T> Update(int id, T product);
        public Task<ReviewDto> AddReview(int productId, ReviewDto review);
        public Task<TriviaDto> AddTrivia(int productId, TriviaDto trivia);
        public Task<TriviaDto> RemoveTrivia(int productId, int triviaId);
    }
}