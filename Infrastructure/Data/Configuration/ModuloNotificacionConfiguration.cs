using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ModuloNotificacionConfiguration : IEntityTypeConfiguration<ModuloNotificacion>
    {
        public void Configure(EntityTypeBuilder<ModuloNotificacion> builder)
        {
            builder.ToTable("ModuloNotificación");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.AsuntoNotificacion)
            .IsRequired()
            .HasMaxLength(80);

            builder.HasOne(p => p.TipoNotificaciones)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdTipoNotificacion);

            builder.HasOne(p => p.Radicados)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdRadicado);

            builder.HasOne(p => p.EstadoVsNotificaciones)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdEstadoVsNotificacion);

            builder.HasOne(p => p.HiloRespuestas)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdHiloRespuesta);

            builder.HasOne(p => p.Formatos)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdFormato);

            builder.HasOne(p => p.TipoRequerimientos)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdTipoRequerimiento);

            builder.Property(p => p.TextoNotificacion)
            .IsRequired()
            .HasMaxLength(2000);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");
            
            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}