using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configuration
{
    public class PermisoGenericoConfiguration : IEntityTypeConfiguration<PermisoGenerico>
    {
        public void Configure(EntityTypeBuilder<PermisoGenerico> builder)
        {
            builder.ToTable("PermisoGenerico"); // Nombre de la Tabla

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
            
            builder.Property(p => p.NombrePermiso)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");  
   
        }

    }
}