using Eventos.IO.Domain.Eventos;
using Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Infra.Data.Mappings
{
    public class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public override void Map(EntityTypeBuilder<Categoria> builder)
        {
            // Mapeamento dos Campos
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            // Campos Ignorados
            builder.Ignore(c => c.ValidationResult);
            builder.Ignore(c => c.CascadeMode);

            // Nome da Tabela
            builder.ToTable("Categorias");
        }        
    }
}
