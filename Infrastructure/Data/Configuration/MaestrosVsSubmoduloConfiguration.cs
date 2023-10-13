using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configuration
{
    public class MaestrosVsSubmoduloConfiguration : IEntityTypeConfiguration<MaestrosVsSubmodulo>
    {
        public void Configure(EntityTypeBuilder<MaestrosVsSubmodulo> builder)
        {
            builder.ToTable("MaestrosVsSubmodulo"); // Nombre de la Tabla

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");  

            builder.HasOne(p => p.ModulosMaestros)
            .WithMany(p => p.MaestrosVsSubmodulos)
            .HasForeignKey(p => p.IdMaestro);

            builder.HasOne(p => p.Submodulos)
            .WithMany(p => p.MaestrosVsSubmodulos)
            .HasForeignKey(p => p.IdSubmodulo);
   
        }

    }
}