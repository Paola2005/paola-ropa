using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estado");
            builder.HasKey(i=>i.Id);
            builder.Property(i=>i.Id);

            builder.Property(r=>r.Descripcion);

            builder.HasOne(y=>y.TiposEsatdos)
            .WithMany(y=>y.Estados)
            .HasForeignKey(y=>y.IdTipoEstado);
        }
    }
}