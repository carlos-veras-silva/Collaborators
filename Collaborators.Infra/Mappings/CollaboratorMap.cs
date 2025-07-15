using Collaborators.Domain.Entities;
using Collaborators.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Collaborators.Infra.Mappings
{
    public class CollaboratorMap : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.ToTable("Colaboradores");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeCompleto)
                .HasColumnType("character varying(200)")
                .IsRequired();

            builder.Property(c => c.CPF)
                .HasColumnType("character varying(11)")
                .IsRequired();

            builder.Property(c => c.RG)
                .HasColumnType("character varying(10)");

            builder.Property(c => c.Email)
                .HasColumnType("character varying(150)");

            builder.Property(c => c.Telefone)
                .HasColumnType("character varying(15)");

            builder.Property(c => c.DataNascimento)
                   .HasColumnType("date");

            builder.Property(c => c.DataAdmissao)
                   .HasColumnType("date");

            builder.Property(c => c.DataDemissao)
                   .HasColumnType("date");

            builder.Property(c => c.Ativo)
                   .HasColumnType("boolean");

            // Configuração detalhada para enums (armazenar como string)
            builder.Property(c => c.Cargo)
                .HasConversion(
                    v => v.ToString(),
                    v => (Cargo)Enum.Parse(typeof(Cargo), v)
                );

            builder.Property(c => c.Departamento)
                .HasConversion(
                    v => v.ToString(),
                    v => (Departamento)Enum.Parse(typeof(Departamento), v)
                );
        }
    }
}

