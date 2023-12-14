using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesodevCase.Entities;

namespace DAL.EntityConfig
{
    public class AdressConfig : IEntityTypeConfiguration<Address>
    // Entity address modelimde fluent api ile gerekli konfigurasyon ayarlirini yapmak icin IEntityTypeConfigurationdan interfacesinden kalitim aldim.
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.City).IsRequired();
            builder.Property(p => p.Country).IsRequired();
            builder.Property(p => p.CityCode).IsRequired();
        }
    }
}
