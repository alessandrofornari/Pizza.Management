using Microsoft.EntityFrameworkCore;
using Pizza.Management.Domain.PizzaManagement.Entities;
using Pizza.Management.Domain.PizzaManagement.Repository;
using System;
using System.Threading.Tasks;

namespace Pizza.Management.Infrastructure.Persistence.CustomerManagementManagement.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<Customer> customers;

        public void Add(Customer customer) => customers.Add(customer);
        public async Task AddAsync(Customer customer) => await customers.AddAsync(customer);

        public async Task SaveChanges() => await dbContext.SaveChangesAsync();

        public CustomerRepository(ApplicationDbContext context)
        {
            this.dbContext = context;
            customers = context.Set<Customer>();
        }

        public async Task<Customer> GetByKey(int id)
        {
            var customer = await customers.FirstOrDefaultAsync(customer => customer.Id == id);

            if (customer == null)
                throw new InvalidOperationException($"Customer with id {id} not found");

            return customer;
        }

        public async Task<Customer> GetByName(string name)
        {
            var customer = await customers.FirstOrDefaultAsync(customer => customer.Name == name);

            if (customer == null)
                throw new InvalidOperationException($"Customer with name {name} not found");

            return customer;
        }
    }
}
