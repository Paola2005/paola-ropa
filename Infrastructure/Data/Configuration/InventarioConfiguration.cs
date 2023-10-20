using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("Inventario");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.HasOne(y=>y.Prendas)
            .WithMany(y=>y.Inventarios)
            .HasForeignKey(y=>y.IdPrenda);
            
            builder.Property(e=>e.ValorVtaCop);
            builder.Property(h=>h.ValorVtaUsd);
            builder.HasIndex(b=>b.CodInvetario)
            .IsUnique();
        }
    }
}