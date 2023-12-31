﻿using BrasilGeo.Domain.Entities.IBGE;
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
            builder.Property(property => property.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .HasColumnType("BIGINT");

            builder.Property(property => property.City)
                .IsRequired()
                .HasColumnName("City")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.OwnsOne(x=>x.State)
                .Property(property => property.Uf)
                .IsRequired()
                .HasColumnName("State")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(5);

        }
    }
}
