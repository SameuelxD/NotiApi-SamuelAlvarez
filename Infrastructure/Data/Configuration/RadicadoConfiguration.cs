using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Infrastructure.Data.Configuration
{
    public class RadicadoConfiguration : IEntityTypeConfiguration<Radicado>
    {
        public void Configure(EntityTypeBuilder<Radicado> builder)
        {
            builder.ToTable("Radicado"); // Nombre de la Tabla

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
            
            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");  
   
        }

    }
}