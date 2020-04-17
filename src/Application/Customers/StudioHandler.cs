using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Studio>> GetAll()
        {
            var studios = await context.Studios.ToListAsync();
            if (studios.Count > 0) { return studios; }
            throw new Exception("No data contained in database");
        }

        public async Task<Studio> GetSingle(int id)
        {
            var studio = await context.Studios.FirstOrDefaultAsync(
                s => s.Id == id);
            if (studio != null) { return studio; }
            throw new Exception("Couldn't find studio with that id");
        }

        public async Task<Studio> Create(Studio studio)
        {
            await context.Studios.AddAsync(studio);
            var success = await context.SaveChangesAsync() > 0;
            if (success) { return studio; }
            throw new Exception("Failed to create customer");
        }

        public async Task<Studio> Delete(int id)
        {
            var studio = await GetSingle(id);
            context.Remove(studio);
            var success = await context.SaveChangesAsync() > 0;
            if (success) { return studio; }
            throw new Exception("Failed to delete customer");
        }

        public async Task<Studio> Update(int id, Studio newStudio)
        {
            var studioToEdit = await GetSingle(id);
            studioToEdit.Name = newStudio.Name;
            studioToEdit.Location = newStudio.Location;
            context.Studios.Update(studioToEdit);
            var success = await context.SaveChangesAsync() > 0;
            
            if (success) { return studioToEdit; }
            throw new Exception("Failed to update studio");
        }
    }
}