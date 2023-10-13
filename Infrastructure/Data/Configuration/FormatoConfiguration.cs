using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configuration
{
    public class FormatoConfiguration : IEntityTypeConfiguration<Formato>
    {
        public void Configure(EntityTypeBuilder<Formato> builder)
        {
            builder.ToTable("Formato"); // Nombre de la Tabla

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.NombreFormato)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime"); 

        }

    }
}