using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InsumoProveedorConfiguration : IEntityTypeConfiguration<InsumoProveedor>
    {
        public void Configure(EntityTypeBuilder<InsumoProveedor> builder)
        {
            builder.ToTable("InsumoProveedor");
            builder.HasKey(t=>new{t.IdInsumo,t.IdProveedor} );
            
            builder.HasOne(y=>y.Insumos)
            .WithMany(y=>y.InsumoProveedores)
            .HasForeignKey(y=>y.IdInsumo);

            builder.HasOne(y=>y.Proveedores)
            .WithMany(y=>y.InsumoProveedores)
            .HasForeignKey(y=>y.IdProveedor);
        }
    }
}