using Eventos.IO.Domain.Eventos;
using Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Infra.Data.Mappings
{
    public class OrganizadorMapping : EntityTypeConfiguration<Organizador>
    {
        public override void Map(EntityTypeBuilder<Organizador> builder)
        {
            // Mapeamento dos Campos
            builder.Property(o => o.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(o => o.Email)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(o => o.CPF)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
                .IsRequired();

            // Campos Ignorados
            builder.Ignore(o => o.ValidationResult);
            builder.Ignore(o => o.CascadeMode);

            // Nome da Tabela
            builder.ToTable("Organizadores");
        }
    }
}
