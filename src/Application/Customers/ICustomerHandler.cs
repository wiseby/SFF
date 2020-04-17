using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Customers
{
    public interface ICustomerHandler<T>
    {
        public Task<List<T>> GetAll();
        public Task<T> GetSingle(int id);
        public Task<T> Create(T customer);
        public Task<T> Delete(int id);
        public Task<T> Update(int id, T customer);
    }
}