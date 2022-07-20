using Pizza.Management.Domain.PizzaManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Management.Domain.PizzaManagement.Repository
{
    public interface IOrderRepository
    {
        //TODO: Add a BaseRepository
        void Add(Order order);
        Task AddAsync(Order order);
        Task SaveChanges();

        Task<Order> GetByCode(string code);
        Task<IEnumerable<Order>> GetAllPendingOrders();

    }
}
