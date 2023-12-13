using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using TesodevCase.Entities;

namespace TesodevCase.DAL.EntityConfig
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.UpdatedAt).IsRequired();

            builder.HasOne(r=> r.Address).WithMany().HasForeignKey(k=>k.AddressId).IsRequired();

            builder.Property(p=> p.AddressId).ValueGeneratedOnAdd();
        }
    }
}
