using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configuration
{
    public class BlockchainConfiguration : IEntityTypeConfiguration<Blockchain>
    {
        public void Configure(EntityTypeBuilder<Blockchain> builder)
        {
            builder.ToTable("Blockchain"); // Nombre de la Tabla

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.HashGenerado)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime"); 

            builder.HasOne(p => p.TiposNotificaciones)
            .WithMany(p => p.Blockchains)
            .HasForeignKey(p => p.IdNotificacion);

            builder.HasOne(p => p.HiloRespuestasNotificaciones)
            .WithMany(p => p.Blockchains)
            .HasForeignKey(p => p.IdHiloRespuesta);

            builder.HasOne(p => p.Auditorias)
            .WithMany(p => p.Blockchains)
            .HasForeignKey(p => p.IdAuditoria); 

        }

    }
}