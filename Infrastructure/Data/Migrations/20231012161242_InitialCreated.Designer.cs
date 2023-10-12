﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(notiAppContext))]
    [Migration("20231012161242_InitialCreated")]
    partial class InitialCreated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Auditoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("DesAccion")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Auditoria", (string)null);
                });

            modelBuilder.Entity("Core.Entities.BlockChain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("HashGenerado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdAuditoria")
                        .HasColumnType("int");

                    b.Property<int>("IdHiloRespuesta")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoNotificacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAuditoria");

                    b.HasIndex("IdHiloRespuesta");

                    b.HasIndex("IdTipoNotificacion");

                    b.ToTable("BlockChain", (string)null);
                });

            modelBuilder.Entity("Core.Entities.EstadoVsNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EstadoNotificación", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Formato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreFormato")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Formato", (string)null);
                });

            modelBuilder.Entity("Core.Entities.GenericoVsSubmodulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("IdMaestroVsSubmodulos")
                        .HasColumnType("int");

                    b.Property<int>("IdPermisoGenerico")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMaestroVsSubmodulos");

                    b.HasIndex("IdPermisoGenerico");

                    b.HasIndex("IdRol");

                    b.ToTable("GenericoVsSubmodulo", (string)null);
                });

            modelBuilder.Entity("Core.Entities.HiloRespuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreTipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("HiloRespuesta", (string)null);
                });

            modelBuilder.Entity("Core.Entities.MaestroVsSubmodulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("IdModuloMaestro")
                        .HasColumnType("int");

                    b.Property<int>("IdSubmodulo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdModuloMaestro");

                    b.HasIndex("IdSubmodulo");

                    b.ToTable("MaestroVsSubmodulo", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ModuloMaestro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreModulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ModuloMaestro", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ModuloNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AsuntoNotificacion")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("IdEstadoVsNotificacion")
                        .HasColumnType("int");

                    b.Property<int>("IdFormato")
                        .HasColumnType("int");

                    b.Property<int>("IdHiloRespuesta")
                        .HasColumnType("int");

                    b.Property<int>("IdRadicado")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoNotificacion")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoRequerimiento")
                        .HasColumnType("int");

                    b.Property<string>("TextoNotificacion")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("IdEstadoVsNotificacion");

                    b.HasIndex("IdFormato");

                    b.HasIndex("IdHiloRespuesta");

                    b.HasIndex("IdRadicado");

                    b.HasIndex("IdTipoNotificacion");

                    b.HasIndex("IdTipoRequerimiento");

                    b.ToTable("ModuloNotificación", (string)null);
                });

            modelBuilder.Entity("Core.Entities.PermisoGenerico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombrePermiso")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PermisoGenerico", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Radicado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Radicado", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("Core.Entities.RolVsMaestro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("IdMaestro")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMaestro");

                    b.HasIndex("IdRol");

                    b.ToTable("RolVsMaestro", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Submodulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreSubmodulo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Submodulo", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreTipo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("TipoNotificación", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoRequerimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("TipoRequerimiento", (string)null);
                });

            modelBuilder.Entity("Core.Entities.BlockChain", b =>
                {
                    b.HasOne("Core.Entities.Auditoria", "Auditorias")
                        .WithMany("BlockChains")
                        .HasForeignKey("IdAuditoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.HiloRespuesta", "HiloRespuestas")
                        .WithMany("BlockChains")
                        .HasForeignKey("IdHiloRespuesta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoNotificacion", "TipoNotificaciones")
                        .WithMany("BlockChains")
                        .HasForeignKey("IdTipoNotificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditorias");

                    b.Navigation("HiloRespuestas");

                    b.Navigation("TipoNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.GenericoVsSubmodulo", b =>
                {
                    b.HasOne("Core.Entities.MaestroVsSubmodulo", "MaestroVsSubmodulos")
                        .WithMany("GenericosVsSubmodulos")
                        .HasForeignKey("IdMaestroVsSubmodulos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.PermisoGenerico", "PermisosGenericos")
                        .WithMany("GenericoSVsSubmodulos")
                        .HasForeignKey("IdPermisoGenerico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Rol", "Roles")
                        .WithMany("GenericosVsSubmodulos")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaestroVsSubmodulos");

                    b.Navigation("PermisosGenericos");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Core.Entities.MaestroVsSubmodulo", b =>
                {
                    b.HasOne("Core.Entities.ModuloMaestro", "ModulosMaestros")
                        .WithMany("MaestrosVsSubmodulos")
                        .HasForeignKey("IdModuloMaestro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Submodulo", "Submodulos")
                        .WithMany("MaestrosVsSubmodulos")
                        .HasForeignKey("IdSubmodulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModulosMaestros");

                    b.Navigation("Submodulos");
                });

            modelBuilder.Entity("Core.Entities.ModuloNotificacion", b =>
                {
                    b.HasOne("Core.Entities.EstadoVsNotificacion", "EstadoVsNotificaciones")
                        .WithMany("ModuloNotificaciones")
                        .HasForeignKey("IdEstadoVsNotificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Formato", "Formatos")
                        .WithMany("ModuloNotificaciones")
                        .HasForeignKey("IdFormato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.HiloRespuesta", "HiloRespuestas")
                        .WithMany("ModuloNotificaciones")
                        .HasForeignKey("IdHiloRespuesta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Radicado", "Radicados")
                        .WithMany("ModuloNotificaciones")
                        .HasForeignKey("IdRadicado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoNotificacion", "TipoNotificaciones")
                        .WithMany("ModuloNotificaciones")
                        .HasForeignKey("IdTipoNotificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoRequerimiento", "TipoRequerimientos")
                        .WithMany("ModuloNotificaciones")
                        .HasForeignKey("IdTipoRequerimiento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoVsNotificaciones");

                    b.Navigation("Formatos");

                    b.Navigation("HiloRespuestas");

                    b.Navigation("Radicados");

                    b.Navigation("TipoNotificaciones");

                    b.Navigation("TipoRequerimientos");
                });

            modelBuilder.Entity("Core.Entities.RolVsMaestro", b =>
                {
                    b.HasOne("Core.Entities.ModuloMaestro", "ModulosMaestros")
                        .WithMany("RolesVsMaestros")
                        .HasForeignKey("IdMaestro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Rol", "Roles")
                        .WithMany("RolesVsMaestros")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModulosMaestros");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Core.Entities.Auditoria", b =>
                {
                    b.Navigation("BlockChains");
                });

            modelBuilder.Entity("Core.Entities.EstadoVsNotificacion", b =>
                {
                    b.Navigation("ModuloNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.Formato", b =>
                {
                    b.Navigation("ModuloNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.HiloRespuesta", b =>
                {
                    b.Navigation("BlockChains");

                    b.Navigation("ModuloNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.MaestroVsSubmodulo", b =>
                {
                    b.Navigation("GenericosVsSubmodulos");
                });

            modelBuilder.Entity("Core.Entities.ModuloMaestro", b =>
                {
                    b.Navigation("MaestrosVsSubmodulos");

                    b.Navigation("RolesVsMaestros");
                });

            modelBuilder.Entity("Core.Entities.PermisoGenerico", b =>
                {
                    b.Navigation("GenericoSVsSubmodulos");
                });

            modelBuilder.Entity("Core.Entities.Radicado", b =>
                {
                    b.Navigation("ModuloNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.Rol", b =>
                {
                    b.Navigation("GenericosVsSubmodulos");

                    b.Navigation("RolesVsMaestros");
                });

            modelBuilder.Entity("Core.Entities.Submodulo", b =>
                {
                    b.Navigation("MaestrosVsSubmodulos");
                });

            modelBuilder.Entity("Core.Entities.TipoNotificacion", b =>
                {
                    b.Navigation("BlockChains");

                    b.Navigation("ModuloNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.TipoRequerimiento", b =>
                {
                    b.Navigation("ModuloNotificaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
