using Microsoft.EntityFrameworkCore;
using Pizza.Management.Domain.PizzaManagement;
using System;
using System.Threading.Tasks;

namespace Pizza.Management.Infrastructure.Persistence.PizzaManagementManagement.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<Domain.PizzaManagement.Entities.Pizza> pizzas;

        public void Add(Domain.PizzaManagement.Entities.Pizza pizza) => pizzas.Add(pizza);
        public async Task AddAsync(Domain.PizzaManagement.Entities.Pizza pizza) => await pizzas.AddAsync(pizza);

        public async Task SaveChanges() => await dbContext.SaveChangesAsync();

        public PizzaRepository(ApplicationDbContext context)
        {
            this.dbContext = context;
            pizzas = context.Set<Domain.PizzaManagement.Entities.Pizza>();
        }

        public async Task<Domain.PizzaManagement.Entities.Pizza> GetByName(string name)
        {
            var pizza = await pizzas.FirstOrDefaultAsync(pizza => pizza.Name == name);

            if (pizza == null)
                throw new InvalidOperationException($"Pizza with name {name} not found");

            return pizza;
        }
    }
}
