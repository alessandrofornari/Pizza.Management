using Pizza.Management.Domain.PizzaManagement.Entities;
using System.Threading.Tasks;

namespace Pizza.Management.Domain.PizzaManagement.Repository
{
    public interface ICustomerRepository
    {
        //TODO: Add a BaseRepository
        void Add(Customer customer);
        Task AddAsync(Customer customer);
        Task SaveChanges();

        Task<Customer> GetByKey(int id);
        Task<Customer> GetByName(string code);
    }
}
