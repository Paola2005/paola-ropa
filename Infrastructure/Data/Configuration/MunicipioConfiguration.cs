using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("Municipio");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.HasOne(y=>y.Departamentos)
            .WithMany(y=>y.Municipios)
            .HasForeignKey(y=>y.IdDepartamento);

            builder.Property(l=>l.Nombre);
        }
    }
}