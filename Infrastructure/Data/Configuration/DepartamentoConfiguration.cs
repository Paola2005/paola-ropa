using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.Property(p=>p.Nombre)
            .IsRequired();

            builder.HasOne(y=>y.Paises)
            .WithMany(y=>y.Departamentos)
            .HasForeignKey(y=>y.IdPais);
        }
    }
}