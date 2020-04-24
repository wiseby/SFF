using Domain;

namespace Application.RentService
{
    public interface IRentService
    {
         public void Rent(Customer customer, Product product);
         public void Return(Customer customer, Product product);
    }
}