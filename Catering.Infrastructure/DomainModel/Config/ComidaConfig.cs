using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Catering.Infrastructure.DomainModel.Config
{
    public class ComidaConfig : IEntityTypeConfiguration<Comida>
    {
        public void Configure(EntityTypeBuilder<Comida> builder)
        {
            builder.ToTable("Comida");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdComida");

            builder.Property(x => x.Nombre)
                .HasColumnName("Nombre");

            var statusConverter = new ValueConverter<ComidaStatus, string>(
                statusEnumValue => statusEnumValue.ToString(),
                status => (ComidaStatus)Enum.Parse(typeof(ComidaStatus), status)
            );

            builder.Property(x => x.Estado)
                 .HasConversion(statusConverter)
                 .HasColumnName("Estado");

            builder.Property(x => x.IdCliente)
                 .HasColumnName("IdCliente")
                 .IsRequired(false);

            builder.Property(x => x.IdOrdenTrabajo)
                 .HasColumnName("IdOrdenTrabajo");

            builder.Property(x => x.IdContrato)
                 .HasColumnName("IdContrato")
                 .IsRequired(false);

            //builder.HasOne<Cliente>()
            //    .WithMany()
            //    .HasForeignKey(x => x.IdCliente)
            //    .HasConstraintName("FK_Comida_Cliente_IdCliente");

            //builder.HasOne<OrdenTrabajo>()
            //    .WithMany()
            //    .HasForeignKey(x => x.IdOrdenTrabajo)
            //    .HasConstraintName("FK_Comida_OrdenTrabajo_IdOrdenTrabajo");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
