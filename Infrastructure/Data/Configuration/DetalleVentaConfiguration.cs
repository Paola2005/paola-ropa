using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVenta");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.Property(e=>e.Cantidad);
            builder.Property(w=>w.ValorUnit);

            builder.HasOne(y=>y.Ventas)
            .WithMany(y=>y.DetallesVentas)
            .HasForeignKey(y=>y.IdVenta);

            builder.HasOne(y=>y.Inventarios)
            .WithMany(y=>y.DetallesVentas)
            .HasForeignKey(y=>y.IdProducto);

            builder.HasOne(y=>y.Tallas)
            .WithMany(y=>y.DetallesVentas)
            .HasForeignKey(y=>y.IdTalla);


        }
    }
}