using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configuration
{
    public class GenericosVsSubmoduloConfiguration : IEntityTypeConfiguration<GenericosVsSubmodulo>
    {
        public void Configure(EntityTypeBuilder<GenericosVsSubmodulo> builder)
        {
            builder.ToTable("GenericosVsSubmodulo"); // Nombre de la Tabla

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");  

            builder.HasOne(p => p.Roles)
            .WithMany(p => p.GenericosVsSubmodulos)
            .HasForeignKey(p => p.IdRol);

            builder.HasOne(p => p.PermisosGenericos)
            .WithMany(p => p.GenericosVsSubmodulos)
            .HasForeignKey(p => p.IdGenerico);

            builder.HasOne(p => p.MaestrosVsSubmodulos)
            .WithMany(p => p.GenericosVsSubmodulos)
            .HasForeignKey(p => p.IdSubmodulo);


        }

    }
}