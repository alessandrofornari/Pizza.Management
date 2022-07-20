using Pizza.Management.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Microsoft.Data.SqlClient;
using Pizza.Management.Domain.PizzaManagement.Repository;
using Pizza.Management.Domain.PizzaManagement;
using Pizza.Management.Infrastructure.Persistence.PizzaManagement.Repository;

namespace Pizza.Management.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

                options.UseLazyLoadingProxies();
            });

            services.AddScoped<IDbConnection>(serviceProvider =>
            {
                SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
                connection.Open();

                return connection;
            });

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
