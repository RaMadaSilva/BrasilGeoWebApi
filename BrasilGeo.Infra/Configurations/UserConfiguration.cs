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
                 .ValueGeneratedOnAdd()
                 .HasColumnName("Id")
                 .HasColumnType("BIGINT");

            builder.OwnsOne(x=>x.Email)
                .Property(x => x.Adress)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250);

            builder.OwnsOne(x=>x.PasswordHash)
                .Property(x => x.Pass)
                .IsRequired()
                .HasColumnName("PasswordHash")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            //Indexar
            builder.HasIndex(x => x.Email, "IX_user_Email")
                .IsUnique();
        }
    }
}
