using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("Venta");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.Property(n=>n.Fecha);

            builder.HasOne(y=>y.Empleados)
            .WithMany(y=>y.Ventas)
            .HasForeignKey(y=>y.IdEmpleado);

            builder.HasOne(y=>y.Clientes)
            .WithMany(y=>y.Ventas)
            .HasForeignKey(y=>y.IdCliente);

            builder.HasOne(y=>y.FormasPagos)
            .WithMany(y=>y.Ventas)
            .HasForeignKey(y=>y.IdFormaPago);
        }
    }
}