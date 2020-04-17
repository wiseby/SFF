using Domain;

namespace Application.RentService
{
    public interface IRentService
    {
         public void Rent(ICustomer customer, IProduct product);
         public void Return(ICustomer customer, IProduct product);
    }
}