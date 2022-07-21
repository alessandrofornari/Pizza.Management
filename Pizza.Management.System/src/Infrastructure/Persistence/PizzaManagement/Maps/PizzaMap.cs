using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pizza.Management.Infrastructure.PizzaManagement.Maps
{
    public class PizzaMap : IEntityTypeConfiguration<Domain.PizzaManagement.Entities.Pizza>
    {
        public void Configure(EntityTypeBuilder<Domain.PizzaManagement.Entities.Pizza> builder)
        {
            builder.ToTable("Pizza");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id);

            builder.Property(x => x.Version).IsRowVersion();
        }
    }
}
