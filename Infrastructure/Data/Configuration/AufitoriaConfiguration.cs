using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class AufitoriaConfiguration : IEntityTypeConfiguration<Auditoria>
{
    public void Configure(EntityTypeBuilder<Auditoria> builder)
    {
        builder.ToTable("Auditoria");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id);

        builder.Property(p => p.NombreUsuario)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.DesAccion)
        .HasColumnType("bigint");

        builder.Property(p => p.FechaCreacion)
        .HasColumnType("datetime");

        builder.Property(p => p.FechaModificacion)
        .HasColumnType("datetime");
    }
}
