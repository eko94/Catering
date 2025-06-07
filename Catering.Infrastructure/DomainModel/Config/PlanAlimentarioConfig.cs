using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.PlanAlimentario;
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
    public class PlanAlimentarioConfig : IEntityTypeConfiguration<PlanAlimentario>
        , IEntityTypeConfiguration<PlanAlimentarioReceta>
    {
        public void Configure(EntityTypeBuilder<PlanAlimentario> builder)
        {
            builder.ToTable("PlanAlimentario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdPlanAlimentario");

            builder.Property(x => x.Nombre)
                .HasColumnName("Nombre");

            builder.Property(x => x.Tipo)
                .HasColumnName("Tipo");

            var quantityDaysConverter = new ValueConverter<PlanAlimentarioCantidadDias, int>(
                quantityValue => quantityValue.Value,
                quantity => new PlanAlimentarioCantidadDias(quantity)
            );

            builder.Property(x => x.CantidadDias)
                .HasConversion(quantityDaysConverter)
                .HasColumnName("CantidadDias");

            builder
                .HasMany(typeof(PlanAlimentarioReceta), "_recetasList")
                .WithOne()
                .HasForeignKey("IdPlanAlimentario")
                .HasConstraintName("FK_PlanAlimentario_PlanAlimentarioReceta_IdPlanAlimentario");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.Recetas);
        }

        public void Configure(EntityTypeBuilder<PlanAlimentarioReceta> builder)
        {
            builder.ToTable("PlanAlimentarioReceta");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdPlanAlimentarioReceta");

            builder.Property(x => x.IdPlanAlimentario)
                .HasColumnName("IdPlanAlimentario");

            builder.Property(x => x.IdReceta)
                 .HasColumnName("IdReceta");

            var dayConverter = new ValueConverter<PlanAlimentarioRecetaDia, int>(
                quantityValue => quantityValue.Value,
                quantity => new PlanAlimentarioRecetaDia(quantity)
            );

            builder.Property(x => x.Dia)
                .HasConversion(dayConverter)
                .HasColumnName("Dia");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
