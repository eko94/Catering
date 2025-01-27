using Catering.Domain.Comidas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Domain.Ingredientes;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Catering.Domain.Shared;

namespace Catering.Infrastructure.DomainModel.Config
{
    public class IngredientesConfig : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            builder.ToTable("Ingrediente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdIngrediente");

            builder.Property(x => x.Nombre)
                .HasColumnName("Nombre");

            builder.Property(x => x.Medicion)
                .HasColumnName("Medicion");

            builder.Property(x => x.Tipo)
                .HasColumnName("Tipo");

            var costConverterVenta = new ValueConverter<CostValue, decimal>(
                costValue => costValue.Value,
                cost => new CostValue(cost)
            );

            builder.Property(x => x.CostoVenta)
                .HasConversion(costConverterVenta)
                .HasColumnName("CostoVenta");

            var costConverterCompra = new ValueConverter<CostValue, decimal>(
                costValue => costValue.Value,
                cost => new CostValue(cost)
            );
            builder.Property(x => x.CostoCompra)
                .HasConversion(costConverterCompra)
                .HasColumnName("CostoCompra");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
