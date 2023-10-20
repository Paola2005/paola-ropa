using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
    {
        public void Configure(EntityTypeBuilder<InventarioTalla> builder)
        {
            builder.ToTable("InventarioTalla");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.HasOne(y=>y.Inventarios)
            .WithMany(y=>y.InventariosTallas)
            .HasForeignKey(y=>y.IdInventario);

            builder.HasOne(y=>y.Tallas)
            .WithMany(y=>y.InventariosTallas)
            .HasForeignKey(y=>y.IdTalla);

            builder.Property(j=>j.Cantidad);
        }
    }
}