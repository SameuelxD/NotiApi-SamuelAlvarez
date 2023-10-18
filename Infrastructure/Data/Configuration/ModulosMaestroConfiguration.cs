using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ModulosMaestroConfiguration : IEntityTypeConfiguration<ModulosMaestro>
    {
        public void Configure(EntityTypeBuilder<ModulosMaestro> builder)
        {
            builder.ToTable("ModulosMaestro"); // Nombre de la Tabla

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
            
            builder.Property(p => p.NombreModulo)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");  
   
        }

    }
}