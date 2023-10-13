using BrasilGeo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrasilGeo.Infra.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           builder.ToTable(nameof(User));

           builder.HasKey(x => x.Id);

           builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

           builder.Property(x => x.Email)
                .IsRequired();

           builder.Property(x => x.PasswordHash)
                .IsRequired();

            //Relacionamento

        }
    }
}
