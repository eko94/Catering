﻿// <auto-generated />
using System;
using Catering.Infrastructure.StoredModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catering.Infrastructure.Migrations
{
    [DbContext(typeof(StoredDbContext))]
    [Migration("20250222224817_InitialStoredDb")]
    partial class InitialStoredDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("9b971b55-e539-4939-9240-825a48402329"),
                            Nombre = "Cliente 1"
                        },
                        new
                        {
                            Id = new Guid("a71010c7-979b-4217-a899-c1c3d8179f4a"),
                            Nombre = "Cliente 2"
                        });
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

                    b.Property<Guid?>("IdCliente")
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("74998d4d-4271-46df-a900-e3c8bcb9020a"),
                            CostoCompra = 10.0m,
                            CostoVenta = 15.0m,
                            Medicion = "kg",
                            Nombre = "Ingrediente 1",
                            Tipo = "Tipo 1"
                        },
                        new
                        {
                            Id = new Guid("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"),
                            CostoCompra = 5.0m,
                            CostoVenta = 8.0m,
                            Medicion = "litro",
                            Nombre = "Ingrediente 2",
                            Tipo = "Tipo 2"
                        });
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

                    b.Property<double>("Cantidad")
                        .HasColumnType("float")
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("75afd017-50b3-4feb-9aa1-6a0cc574da16"),
                            Cantidad = 1.0,
                            Detalle = "",
                            IdIngrediente = new Guid("74998d4d-4271-46df-a900-e3c8bcb9020a"),
                            IdReceta = new Guid("38b29f41-0757-4f98-af43-84394606eb03")
                        },
                        new
                        {
                            Id = new Guid("d390daf8-4432-4789-8620-a3f40713dfe4"),
                            Cantidad = 2.0,
                            Detalle = "",
                            IdIngrediente = new Guid("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"),
                            IdReceta = new Guid("38b29f41-0757-4f98-af43-84394606eb03")
                        },
                        new
                        {
                            Id = new Guid("779f2031-c59a-4d99-a579-3b30fbc9d454"),
                            Cantidad = 1.0,
                            Detalle = "",
                            IdIngrediente = new Guid("74998d4d-4271-46df-a900-e3c8bcb9020a"),
                            IdReceta = new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227")
                        },
                        new
                        {
                            Id = new Guid("85c16f52-56c3-4dba-ad45-ea4f5fe47cc4"),
                            Cantidad = 2.0,
                            Detalle = "",
                            IdIngrediente = new Guid("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"),
                            IdReceta = new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227")
                        });
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("840c14b1-2aab-44b5-ba2e-336a17a4c38c"),
                            IdReceta = new Guid("38b29f41-0757-4f98-af43-84394606eb03"),
                            Instruccion = "Instruccion 1"
                        },
                        new
                        {
                            Id = new Guid("47eda952-9d17-45e6-a91d-7126290d8912"),
                            IdReceta = new Guid("38b29f41-0757-4f98-af43-84394606eb03"),
                            Instruccion = "Instruccion 2"
                        },
                        new
                        {
                            Id = new Guid("880fabc1-fc37-4940-8126-45f4ea076c00"),
                            IdReceta = new Guid("38b29f41-0757-4f98-af43-84394606eb03"),
                            Instruccion = "Instruccion 3"
                        },
                        new
                        {
                            Id = new Guid("99d49146-f040-4f66-b86b-237fec692687"),
                            IdReceta = new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"),
                            Instruccion = "Instruccion 1"
                        },
                        new
                        {
                            Id = new Guid("9b37bd7e-4cf2-4a38-b9bf-cc047d6d52c1"),
                            IdReceta = new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"),
                            Instruccion = "Instruccion 2"
                        },
                        new
                        {
                            Id = new Guid("1e055008-742c-4c3b-901b-f371156bfead"),
                            IdReceta = new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"),
                            Instruccion = "Instruccion 3"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("38b29f41-0757-4f98-af43-84394606eb03"),
                            Nombre = "Receta 1"
                        },
                        new
                        {
                            Id = new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"),
                            Nombre = "Receta 2"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("d19a0e52-cf2a-45cb-a99f-7343afb296b4"),
                            Nombre = "Usuario cocinero 1"
                        },
                        new
                        {
                            Id = new Guid("76084be0-b170-44e8-a302-a4b7b34927d6"),
                            Nombre = "Usuario cocinero 2"
                        });
                });

            modelBuilder.Entity("Catering.Infrastructure.StoredModel.Entities.ComidaStoredModel", b =>
                {
                    b.HasOne("Catering.Infrastructure.StoredModel.Entities.ClienteStoredModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente");

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
