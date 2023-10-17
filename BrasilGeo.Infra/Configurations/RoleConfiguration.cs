using BrasilGeo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrasilGeo.Infra.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .IsRequired()
                 .HasColumnName("Id")
                 .HasColumnType("BIGINT")
                 .ValueGeneratedOnAdd();

            builder.Property(x => x.RoleName)
                 .IsRequired()
                 .HasColumnName("RoleName")
                 .HasColumnType("NVARCHAR")
                 .HasMaxLength(50);

            //Relacionamento

            builder.HasMany(x => x.Users)
                .WithMany(x => x.Roles)
                .UsingEntity<Dictionary<string, object>>("UserRole", user => 
                user
                .HasOne<User>()
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade),
                role => role
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey("RoleId")
                .OnDelete(DeleteBehavior.Cascade)
                ); 
        }
    }
}
