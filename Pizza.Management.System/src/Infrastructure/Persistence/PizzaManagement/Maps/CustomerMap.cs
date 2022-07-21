using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Management.Domain.PizzaManagement.Entities;

namespace Pizza.Management.Infrastructure.PizzaManagement.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id);

            builder.Property(x => x.Version).IsRowVersion();
        }
    }
}
