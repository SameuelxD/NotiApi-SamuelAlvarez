using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class SubmoduloConfiguration : IEntityTypeConfiguration<Submodulo>
    {
        public void Configure(EntityTypeBuilder<Submodulo> builder)
        {
            builder.ToTable("Submodulo"); // Nombre de la Tabla

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
        
            builder.Property(p => p.NombreSubmodulo)
            .IsRequired()
            .HasMaxLength(80);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
   
        }

    }
}