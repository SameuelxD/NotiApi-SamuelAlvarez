using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configuration
{
    public class ModuloNotificacionConfiguration : IEntityTypeConfiguration<ModulosNotificacion>
    {
        public void Configure(EntityTypeBuilder<ModulosNotificacion> builder)
        {
            builder.ToTable("ModulosNotificacion"); // Nombre de la Tabla

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
            
            builder.Property(p => p.AsuntoNotificacion)
            .IsRequired()
            .HasMaxLength(80);

            builder.Property(p => p.TextoNotificacion)
            .IsRequired()
            .HasMaxLength(2000);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");  

            builder.HasOne(p => p.Radicados)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdRadicado);

            builder.HasOne(p => p.Formatos)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdFormato);

            builder.HasOne(p => p.EstadosNotificaciones)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdEstadoNotificacion);

            builder.HasOne(p => p.TiposRequerimientos)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdRequerimiento);

            builder.HasOne(p => p.HiloRespuestasNotificaciones)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdHiloRespuesta);

            builder.HasOne(p => p.TiposNotificaciones)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdNotificacion);

        }

    }
}