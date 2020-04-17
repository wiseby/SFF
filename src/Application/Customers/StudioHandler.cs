using System;
using System.Collections.Generic;
using Domain;
using Persistence;

namespace Application.Customers
{
    public class StudioHandler : ICustomerHandler<Studio>
    {
        private List<ICustomer> customers;
        private readonly DataContext context;


        public StudioHandler(DataContext context)
        {
            this.context = context;
            customers = new List<ICustomer>();
        }


        public void Add(ICustomer customer)
        {
            customers.Add(customer);
        }

        public void ChangeStudioInfo(int id, string[] data)
        {
            var customer = customers.Find(o => o.Id == id);
            if (customer == null) { throw new ArgumentNullException(); }
            if(data[0] != null) { customer.Title = data[0]; }
            if(data[1] != null) { customer.Location = data[1]; }
        }

        public List<ICustomer> GetAll()
        {
            return customers;
        }

        public void RemoveStudio(int id)
        {
            var studio = customers.Find(s => s.Id == id);
            customers.Remove(studio);
        }

        public void ChangeInfo(ICustomer customer, string[] data)
        {
            throw new NotImplementedException();
        }
    }
}