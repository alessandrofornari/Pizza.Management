using System.Threading.Tasks;

namespace Pizza.Management.Domain.PizzaManagement
{
    public interface IPizzaRepository
    {
        //TODO: Add a BaseRepository
        void Add(Entities.Pizza pizza);
        Task AddAsync(Entities.Pizza pizza);
        Task SaveChanges();
        
        Task<Entities.Pizza> GetByName(string name);
    }
}
