using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Management.Domain.PizzaManagement.Entities;
using System;

namespace Pizza.Management.Infrastructure.PizzaManagement.Maps
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id);

            builder.Property(p => p.CustomerId);

            builder.Property(x => x.Version).IsRowVersion();

            builder.HasMany(x => x.Pizzas)
                .WithOne()
                .HasForeignKey(p => p.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
