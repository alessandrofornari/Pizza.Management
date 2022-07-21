using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Management.Domain.PizzaManagement.Entities;

namespace Pizza.Management.Infrastructure.PizzaManagement.Maps
{
    public class PizzaOrderMap : IEntityTypeConfiguration<PizzaOrder>
    {
        public void Configure(EntityTypeBuilder<PizzaOrder> builder)
        {
            builder.ToTable("PizzaOrder");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id);

            builder.Property(p => p.OrderId);

            builder.Property(p => p.PizzaId);
        }
    }
}
