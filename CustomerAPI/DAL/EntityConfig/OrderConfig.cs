using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using System.Text.Json.Serialization;
using TesodevCase.Entities;


namespace TesodevCase.DAL.EntityConfig
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p =>p.Quantity).IsRequired();
            builder.Property(p =>p.Price).IsRequired();
            builder.Property(p =>p.Status).IsRequired();
            builder.Property(p =>p.Address).IsRequired();
            builder.Property(p=>p.Product).IsRequired();
            builder.Property(p=>p.CreatedAt).IsRequired();
            builder.Property(p=>p.UpdatedAt).IsRequired();

            builder.HasOne(r => r.Address).WithMany().HasForeignKey(r => r.AddressId).IsRequired();
            builder.Property(p=>p.AddressId).ValueGeneratedOnAdd();

            builder.HasOne(r=>r.Product).WithOne().HasForeignKey<Order>(r => r.ProductId).IsRequired();
            builder.Property(p => p.ProductId).ValueGeneratedOnAdd();

            builder.HasOne<Customer>(e => e.Customer).WithMany(e => e.Orders).IsRequired().HasForeignKey(e => e.CustomerId).HasPrincipalKey(e => e.Id);

            
        }
    }
}
