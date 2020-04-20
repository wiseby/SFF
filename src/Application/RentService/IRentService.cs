using Domain;

namespace Application.RentService
{
    public interface IRentService
    {
         public void Rent(Studio customer, Movie product);
         public void Return(Studio customer, Movie product);
    }
}