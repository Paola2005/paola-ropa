using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
    {
        public void Configure(EntityTypeBuilder<Prenda> builder)
        {
            builder.ToTable("Prenda");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.Property(q=>q.IdPrenda);
            builder.Property(q=>q.Nombre);
            builder.Property(q=>q.ValorUnitCop);
            builder.Property(q=>q.ValorUnitUsd);

            builder.HasOne(y=>y.TiposProtecciones)
            .WithMany(y=>y.Prendas)
            .HasForeignKey(y=>y.IdTipoProteccion);

            builder.HasOne(y=>y.Generos)
            .WithMany(y=>y.Prendas)
            .HasForeignKey(y=>y.IdGenero);


        }
    }
}