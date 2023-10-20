using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
    {
        public void Configure(EntityTypeBuilder<Insumo> builder)
        {
            builder.ToTable("Insumo");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.HasIndex(p=>p.Nombre)
            .IsUnique();
            builder.Property(t=>t.ValorUnit);
            builder.Property(w=>w.StockMin);
            builder.Property(q=>q.StockMax);
        }
    }
}