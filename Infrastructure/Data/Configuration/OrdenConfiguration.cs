using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.ToTable("Orden");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.Property(q=>q.Fecha);

            builder.HasOne(y=>y.Empleados)
            .WithMany(y=>y.Ordenes)
            .HasForeignKey(y=>y.IdEmleado);

            builder.HasOne(y=>y.Clientes)
            .WithMany(y=>y.Ordenes)
            .HasForeignKey(y=>y.IdCliente);

            builder.HasOne(y=>y.Estados)
            .WithMany(y=>y.Ordenes)
            .HasForeignKey(y=>y.IdEstado);
        }
    }
}