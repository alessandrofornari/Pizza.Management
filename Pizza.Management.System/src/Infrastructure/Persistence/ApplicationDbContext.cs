using Microsoft.EntityFrameworkCore;
using Pizza.Management.Domain.PizzaManagement.Entities;
using System.Reflection;

namespace Pizza.Management.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Domain.PizzaManagement.Entities.Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PizzaOrder> PizzaOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
