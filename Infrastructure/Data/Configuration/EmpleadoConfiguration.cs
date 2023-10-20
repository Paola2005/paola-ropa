using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.HasIndex(t=>t.IdEmleado)
            .IsUnique();

            builder.Property(m=>m.Nombre);
            builder.Property(k=>k.FechaIngreso);

            builder.HasOne(y=>y.Cargos)
            .WithMany(y=>y.Empleado)
            .HasForeignKey(y=>y.IdCargo);

            builder.HasOne(y=>y.Municipios)
            .WithMany(y=>y.Empleado)
            .HasForeignKey(y=>y.IdMunicipio);
        }
    }
}