using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;
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

            builder.HasMany(typeof(RecetaIngrediente), "_ingredientesList")
                .WithOne()
                .HasForeignKey("IdReceta")
                .HasConstraintName("FK_RecetaIngrediente_Receta");

            builder.HasMany(typeof(RecetaInstruccion), "_instruccionesList")
                .WithOne()
                .HasForeignKey("IdReceta")
                .HasConstraintName("FK_RecetaInstruccion_Receta");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }

        public void Configure(EntityTypeBuilder<RecetaIngrediente> builder)
        {
            builder.ToTable("RecetaIngrediente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdRecetaIngrediente");

            builder.Property(x => x.IdReceta)
                .HasColumnName("IdReceta");

            builder.Property(x => x.IdIngrediente)
                .HasColumnName("IdIngrediente");

            builder.Property(x => x.Detalle)
                .HasColumnName("Detalle");

            var quantityConverter = new ValueConverter<RecetaIngredienteCantidad, float>(
                    quantityValue => quantityValue.Value,
                    quantity => new RecetaIngredienteCantidad(quantity)
                );

            builder.Property(x => x.Cantidad)
                .HasConversion(quantityConverter)
                .HasColumnName("Cantidad");

            builder.HasOne<Receta>()
                .WithMany()
                .HasForeignKey(x => x.IdReceta)
                .HasConstraintName("FK_RecetaIngrediente_Receta");

            builder.HasOne<Ingrediente>()
                .WithMany()
                .HasForeignKey(x => x.IdIngrediente)
                .HasConstraintName("FK_RecetaIngrediente_Ingrediente");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }

        public void Configure(EntityTypeBuilder<RecetaInstruccion> builder)
        {
            builder.ToTable("RecetaInstruccion");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdRecetaInstruccion");

            builder.Property(x => x.IdReceta)
                .HasColumnName("IdReceta");

            builder.Property(x => x.Instruccion)
                .HasColumnName("Instruccion");

            builder.HasOne<Receta>()
                .WithMany()
                .HasForeignKey(x => x.IdReceta)
                .HasConstraintName("FK_RecetaInstruccion_Receta");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
