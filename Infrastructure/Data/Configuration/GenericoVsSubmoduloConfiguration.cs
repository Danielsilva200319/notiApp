using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class GenericoVsSubmoduloConfiguration : IEntityTypeConfiguration<GenericoVsSubmodulo>
    {
        public void Configure(EntityTypeBuilder<GenericoVsSubmodulo> builder)
        {
            builder.ToTable("GenericoVsSubmodulo");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(p => p.PermisosGenericos)
            .WithMany(p => p.GenericoSVsSubmodulos)
            .HasForeignKey(p => p.IdPermisoGenerico);

            builder.HasOne(p => p.MaestroVsSubmodulos)
            .WithMany(p => p.GenericosVsSubmodulos)
            .HasForeignKey(p => p.IdMaestroVsSubmodulos);

            builder.HasOne(p => p.Roles)
            .WithMany(p => p.GenericosVsSubmodulos)
            .HasForeignKey(p => p.IdRol);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");
            
            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}