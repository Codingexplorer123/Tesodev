using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using System.Text.Json.Serialization;
using TesodevCase.Entities;
using Newtonsoft.Json;

namespace DAL.EntityConfig
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Address).IsRequired();
            builder.Property(p => p.Product).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.UpdatedAt).IsRequired();

            builder.HasOne<Customer>(e => e.Customer).WithMany(e => e.Orders).IsRequired().HasForeignKey(e => e.CustomerId).HasPrincipalKey(e => e.Id);

            // Newtonsoft paketi ile json objeleri string degelere ve string degerleri json objesine donduruyoruz.
            builder.Property(p => p.Address).HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<Address>(v));
            builder.Property(p => p.Product).HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<Product>(v));
            builder.Property(p => p.Customer).HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<Customer>(v));
        }
    }
}
