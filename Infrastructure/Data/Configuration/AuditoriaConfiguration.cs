using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>
    {
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {
            builder.ToTable("Auditoria"); // Nombre de la Tabla

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
            
            builder.Property(p => p.NombreUsuario)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.DescAccion)
            .HasColumnType("int");

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");  

            
   
        }

    }
}