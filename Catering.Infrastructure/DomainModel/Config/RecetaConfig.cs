using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
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
    public class RecetaConfig : IEntityTypeConfiguration<Receta>,
        IEntityTypeConfiguration<RecetaIngrediente>,
        IEntityTypeConfiguration<RecetaInstruccion>
    {
        public void Configure(EntityTypeBuilder<Receta> builder)
        {
            builder.ToTable("Receta");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdReceta");

            builder.Property(x => x.Nombre)
                .HasColumnName("Nombre");

            builder.HasMany(typeof(RecetaIngrediente), "_ingredientesList");

            builder.HasMany(typeof(RecetaInstruccion), "_instruccionesList");            

            builder.HasMany(typeof(Comida), "_comidasList");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }

        public void Configure(EntityTypeBuilder<RecetaIngrediente> builder)
        {
            builder.ToTable("RecetaIngrediente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdRecetaIngrediente");

            builder.Property(x => x.Detalle)
                .HasColumnName("Detalle");

            var quantityConverter = new ValueConverter<RecetaIngredienteCantidad, float>(
                    quantityValue => quantityValue.Value,
                    quantity => new RecetaIngredienteCantidad(quantity)
                );

            builder.Property(x => x.Cantidad)
                .HasConversion(quantityConverter)
                .HasColumnName("Cantidad");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }

        public void Configure(EntityTypeBuilder<RecetaInstruccion> builder)
        {
            builder.ToTable("RecetaInstruccion");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdRecetaInstruccion");

            builder.Property(x => x.Instruccion)
                .HasColumnName("Instruccion");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
