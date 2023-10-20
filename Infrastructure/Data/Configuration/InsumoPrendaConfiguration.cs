using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
    {
        public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
        {
            builder.ToTable("InsumoPrenda");
            builder.HasKey(t=>new{t.IdInsumo,t.IdPrenda} );
            
            builder.HasOne(y=>y.Insumos)
            .WithMany(y=>y.InsumoPrendas)
            .HasForeignKey(y=>y.IdInsumo);

            builder.HasOne(y=>y.Prendas)
            .WithMany(y=>y.InsumoPrendas)
            .HasForeignKey(y=>y.IdPrenda);

            builder.Property(x=>x.Cantidad);

        }
    }
}