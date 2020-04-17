using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application.Products
{
    public interface IProductHandler<T>
    {
        public Task<List<T>> GetAll();
        public Task<T> GetSingle(int id);
        public Task<T> Create(T product);
        public Task<T> Delete(int id);
        public Task<T> Update(int id, T product);
    }
}