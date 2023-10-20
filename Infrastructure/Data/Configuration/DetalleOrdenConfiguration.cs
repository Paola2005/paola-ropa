using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
    {
        public void Configure(EntityTypeBuilder<DetalleOrden> builder)
        {
            builder.ToTable("DetalleOrden");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.HasOne(y=>y.Ordenes)
            .WithMany(y=>y.DetalleOrdenes)
            .HasForeignKey(y=>y.IdOrden);

            builder.HasOne(y=>y.Prendas)
            .WithMany(y=>y.DetalleOrdenes)
            .HasForeignKey(y=>y.IdPrenda);

            builder.HasOne(y=>y.Colores)
            .WithMany(y=>y.DetalleOrdenes)
            .HasForeignKey(y=>y.IdColor);

            builder.HasOne(y=>y.Estados)
            .WithMany(y=>y.DetalleOrdenes)
            .HasForeignKey(y=>y.IdEstado);

            builder.Property(l=>l.CantidadProducir);
            builder.Property(m=>m.CantidadProducida);

            

            
        }
    }
}