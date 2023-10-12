using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configuration
{
    public class TipoNotificacionConfiguration : IEntityTypeConfiguration<TipoNotificacion>
    {
        public void Configure(EntityTypeBuilder<TipoRequerimiento> builder)
        {
            builder.ToTable("TipoNotificacion"); // Nombre de la Tabla

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
        
            builder.Property(p => p.NombreTipo)
            .IsRequired()
            .HasMaxLength(80);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
   
        }

    }
}