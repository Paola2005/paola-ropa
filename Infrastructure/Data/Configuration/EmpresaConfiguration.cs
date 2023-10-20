using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.HasIndex(w=>w.Nit)
            .IsUnique();

            builder.Property(k=>k.RazonSocial);
            builder.Property(d=>d.RepresentanteLegal);
            
            builder.Property(e=>e.FechaCreacion);

            builder.HasOne(y=>y.Municipios)
            .WithMany(y=>y.Empresas)
            .HasForeignKey(y=>y.IdMunicipio);
        }
    }
}