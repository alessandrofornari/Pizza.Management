using Microsoft.EntityFrameworkCore;
using Pizza.Management.Domain.PizzaManagement.Entities;
using Pizza.Management.Domain.PizzaManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Management.Infrastructure.Persistence.PizzaManagementManagement.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<Order> orders;

        public void Add(Order order) => orders.Add(order);
        public async Task AddAsync(Order order) => await orders.AddAsync(order);

        public async Task SaveChanges() => await dbContext.SaveChangesAsync();

        public OrderRepository(ApplicationDbContext context)
        {
            this.dbContext = context;
            orders = context.Set<Order>();
        }

        public async Task<Order> GetByCode(string code)
        {
            var order = await orders.FirstOrDefaultAsync(order => order.Code == code);

            if (order == null)
                throw new InvalidOperationException($"Order with code {code} not found");

            return order;
        }

        public async Task<IEnumerable<Order>> GetAllPendingOrders()
        {
            var result = await orders.Where(order => order.IsDelivered == false).OrderBy(order => order.Id).ToListAsync();

            return result;
        }
    }
}
