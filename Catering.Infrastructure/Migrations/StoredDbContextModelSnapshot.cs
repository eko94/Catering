﻿// <auto-generated />
using System;
using Catering.Infrastructure.StoredModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catering.Infrastructure.Migrations
{
    [DbContext(typeof(StoredDbContext))]
    partial class StoredDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.ClienteStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdCliente");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.ComidaStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdComida");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Estado");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdOrdenTrabajo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdOrdenTrabajo");

                    b.ToTable("Comida");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.IngredienteStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdIngrediente");

                    b.Property<decimal>("CostoCompra")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("CostoCompra");

                    b.Property<decimal>("CostoVenta")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("CostoVenta");

                    b.Property<string>("Medicion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Medicion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Tipo");

                    b.HasKey("Id");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.OrdenTrabajoClienteStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdOrdenTrabajoCliente");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdOrdenTrabajo")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdOrdenTrabajo");

                    b.ToTable("OrdenTrabajoCliente");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.OrdenTrabajoStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdOrdenTrabajo");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("Cantidad");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Estado");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreado");

                    b.Property<Guid>("IdReceta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuarioCocinero")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("IdReceta");

                    b.HasIndex("IdUsuarioCocinero");

                    b.ToTable("OrdenTrabajo");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.RecetaIngredienteStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdRecetaIngrediente");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Cantidad");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Detalle");

                    b.Property<Guid>("IdIngrediente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdReceta")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdIngrediente");

                    b.HasIndex("IdReceta");

                    b.ToTable("RecetaIngrediente");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.RecetaInstruccionStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdRecetaInstruccion");

                    b.Property<Guid>("IdReceta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Instruccion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Instruccion");

                    b.HasKey("Id");

                    b.HasIndex("IdReceta");

                    b.ToTable("RecetaInstruccion");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.RecetaStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdReceta");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Receta");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.UsuarioStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdUsuario");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.ComidaStoredModel", b =>
                {
                    b.HasOne("Catering.Infrastructure.StoredModel.Entities.ClienteStoredModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catering.Infrastructure.StoredModel.Entities.OrdenTrabajoStoredModel", "OrdenTrabajo")
                        .WithMany("Comidas")
                        .HasForeignKey("IdOrdenTrabajo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("OrdenTrabajo");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.OrdenTrabajoClienteStoredModel", b =>
                {
                    b.HasOne("Catering.Infrastructure.StoredModel.Entities.ClienteStoredModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catering.Infrastructure.StoredModel.Entities.OrdenTrabajoStoredModel", "OrdenTrabajo")
                        .WithMany("Clientes")
                        .HasForeignKey("IdOrdenTrabajo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("OrdenTrabajo");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.OrdenTrabajoStoredModel", b =>
                {
                    b.HasOne("Catering.Infrastructure.StoredModel.Entities.RecetaStoredModel", "Receta")
                        .WithMany()
                        .HasForeignKey("IdReceta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catering.Infrastructure.StoredModel.Entities.UsuarioStoredModel", "UsuarioCocinero")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCocinero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receta");

                    b.Navigation("UsuarioCocinero");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.RecetaIngredienteStoredModel", b =>
                {
                    b.HasOne("Catering.Infrastructure.StoredModel.Entities.IngredienteStoredModel", "Ingrediente")
                        .WithMany()
                        .HasForeignKey("IdIngrediente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catering.Infrastructure.StoredModel.Entities.RecetaStoredModel", "Receta")
                        .WithMany("Ingredientes")
                        .HasForeignKey("IdReceta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Receta");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.RecetaInstruccionStoredModel", b =>
                {
                    b.HasOne("Catering.Infrastructure.StoredModel.Entities.RecetaStoredModel", "Receta")
                        .WithMany("Instrucciones")
                        .HasForeignKey("IdReceta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receta");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.OrdenTrabajoStoredModel", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Comidas");
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.RecetaStoredModel", b =>
                {
                    b.Navigation("Ingredientes");

                    b.Navigation("Instrucciones");
                });
#pragma warning restore 612, 618
        }
    }
}
