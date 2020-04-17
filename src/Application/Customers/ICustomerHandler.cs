using Domain;

namespace Application.Customers
{
    public interface ICustomerHandler<T>
    {
         public void ChangeInfo(ICustomer customer, string[] data);
    }
}