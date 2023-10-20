using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedor");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.HasIndex(q=>q.NitProveedor)
            .IsUnique();

            builder.Property(q=>q.Nombre);

            builder.HasOne(y=>y.TipoPersonas)
            .WithMany(y=>y.Proveedores)
            .HasForeignKey(y=>y.IdTipoPersona);

            builder.HasOne(y=>y.Municipios)
            .WithMany(y=>y.Proveedores)
            .HasForeignKey(y=>y.IdMunicipio);
        }
    }
}