using BrasilGeo.Domain.Entities.IBGE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrasilGeo.Infra.Configurations
{
    public class LocationIBGEConfiguration : IEntityTypeConfiguration<LocationIBGE>
    {
        public void Configure(EntityTypeBuilder<LocationIBGE> builder)
        {
            builder.ToTable(nameof(LocationIBGE));
            builder.HasKey(property => property.Id);
            builder.Property(property => property.Id).IsRequired();
            builder.Property(property => property.City).IsRequired();
            builder.Property(property => property.State).IsRequired();
        }
    }
}
