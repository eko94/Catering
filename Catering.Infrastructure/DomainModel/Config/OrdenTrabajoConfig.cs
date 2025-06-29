using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.DomainModel.Config
{
    public class OrdenTrabajoConfig : IEntityTypeConfiguration<OrdenTrabajo>
        ,IEntityTypeConfiguration<OrdenTrabajoCliente>
    {
        public void Configure(EntityTypeBuilder<OrdenTrabajo> builder)
        {
            builder.ToTable("OrdenTrabajo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdOrdenTrabajo");

            builder.Property(x => x.IdUsuarioCocinero)
                .HasColumnName("IdUsuarioCocinero");

            builder.Property(x => x.IdReceta)
                .HasColumnName("IdReceta");

            var quantityConverter = new ValueConverter<OrdenTrabajoCantidad, int>(
                quantityValue => quantityValue.Value,
                quantity => new OrdenTrabajoCantidad(quantity)
            );

            builder.Property(x => x.Cantidad)
                .HasConversion(quantityConverter)
                .HasColumnName("Cantidad");

            var statusConverter = new ValueConverter<OrdenTrabajoStatus, string>(
                statusEnumValue => statusEnumValue.ToString(),
                status => (OrdenTrabajoStatus)Enum.Parse(typeof(OrdenTrabajoStatus), status)
            );
            builder.Property(x => x.Estado)
                 .HasConversion(statusConverter)
                 .HasColumnName("Estado");

            var typeConverter = new ValueConverter<OrdenTrabajoType, string>(
                typeEnumValue => typeEnumValue.ToString(),
                status => (OrdenTrabajoType)Enum.Parse(typeof(OrdenTrabajoType), status)
            );
            builder.Property(x => x.Tipo)
                 .HasConversion(typeConverter)
                 .HasColumnName("Tipo");

            builder
                .HasMany(typeof(Comida), "_comidasList")
                .WithOne()
                .HasForeignKey("IdOrdenTrabajo")
                .HasConstraintName("FK_Comida_OrdenTrabajo_IdOrdenTrabajo");

            builder
                .HasMany(typeof(OrdenTrabajoCliente), "_clientesList")
                .WithOne()
                .HasForeignKey("IdOrdenTrabajo")
                .HasConstraintName("FK_OrdenTrabajoCliente_OrdenTrabajo_IdOrdenTrabajo");

            builder.Property(x => x.FechaCreado)
                .HasColumnName("FechaCreado");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.Comidas);
            builder.Ignore(x => x.Clientes);
        }

        public void Configure(EntityTypeBuilder<OrdenTrabajoCliente> builder)
        {
            builder.ToTable("OrdenTrabajoCliente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdOrdenTrabajoCliente");            

            builder.Property(x => x.IdOrdenTrabajo)
                 .HasColumnName("IdOrdenTrabajo");

            builder.Property(x => x.IdCliente)
                 .HasColumnName("IdCliente");

            builder.Property(x => x.IdContrato)
                 .HasColumnName("IdContrato");

            //builder.HasOne<Cliente>()
            //    .WithMany()
            //    .HasForeignKey(x => x.IdCliente)
            //    .HasConstraintName("FK_OrdenTrabajoCliente_Cliente_IdCliente");

            //builder.HasOne<OrdenTrabajo>()
            //    .WithMany()
            //    .HasForeignKey(x => x.IdOrdenTrabajo)
            //    .HasConstraintName("FK_OrdenTrabajoCliente_OrdenTrabajo_IdOrdenTrabajo");


            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
