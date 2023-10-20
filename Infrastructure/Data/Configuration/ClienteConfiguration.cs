using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.HasIndex(u=>u.IdCliente)
            .IsUnique();

            builder.Property(o=>o.Nombre);

            builder.HasOne(y=>y.TiposPersonas)
            .WithMany(y=>y.Clientes)
            .HasForeignKey(y=>y.IdTipoPersona);

            builder.HasOne(s=>s.Municipios)
            .WithMany(s=>s.Clientes)
            .HasForeignKey(s=>s.IdMunicipio);

            builder.Property(r=>r.FechaRegistro);
            

        }
    }
}