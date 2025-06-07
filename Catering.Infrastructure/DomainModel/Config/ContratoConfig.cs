using Catering.Domain.Comidas;
using Catering.Domain.Contratos;
using Catering.Domain.OrdenesTrabajo;
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
    public class ContratoConfig : IEntityTypeConfiguration<Contrato>,
        IEntityTypeConfiguration<ContratoEntregaCancelada>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.ToTable("Contrato");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdContrato");

            builder.Property(x => x.IdCliente)
                .HasColumnName("IdCliente");

            builder.Property(x => x.IdPlanAlimentario)
                .HasColumnName("IdPlanAlimentario");

            var quantityContractDaysConverter = new ValueConverter<ContratoDiasContratados, int>(
                quantityValue => quantityValue.Value,
                quantity => new ContratoDiasContratados(quantity)
            );
            builder.Property(x => x.DiasContratados)
                .HasConversion(quantityContractDaysConverter)
                .HasColumnName("DiasContratados");

            var quantityContractDaysDoneConverter = new ValueConverter<ContratoDiasRealizados, int>(
                quantityValue => quantityValue.Value,
                quantity => new ContratoDiasRealizados(quantity)
            );
            builder.Property(x => x.DiasRealizados)
                .HasConversion(quantityContractDaysDoneConverter)
                .HasColumnName("DiasRealizados");

            var statusConverter = new ValueConverter<ContratoStatus, string>(
                statusEnumValue => statusEnumValue.ToString(),
                status => (ContratoStatus)Enum.Parse(typeof(ContratoStatus), status)
            );
            builder.Property(x => x.Estado)
                 .HasConversion(statusConverter)
                 .HasColumnName("Estado");

            builder.Property(x => x.FechaInicio)
                .HasColumnName("FechaInicio");

            builder.Property(x => x.FechaUltimoRealizado)
                .HasColumnName("FechaUltimoRealizado");

            builder
                .HasMany(typeof(ContratoEntregaCancelada), "_entregasCanceladasList")
                .WithOne()
                .HasForeignKey("IdContrato")
                .HasConstraintName("FK_ContratoEntregaCancelada_Contrato_IdContrato");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.EntregasCanceladas);
        }

        public void Configure(EntityTypeBuilder<ContratoEntregaCancelada> builder)
        {
            builder.ToTable("ContratoEntregaCancelada");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdContratoEntregaCancelada");

            builder.Property(x => x.IdContrato)
                .HasColumnName("IdContrato");

            builder.Property(x => x.FechaCancelada)
                .HasColumnName("FechaCancelada");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
