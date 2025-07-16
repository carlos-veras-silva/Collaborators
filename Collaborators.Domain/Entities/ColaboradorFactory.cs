using Collaborators.Domain.Enums;
using System;

namespace Collaborators.Domain.Entities;

public static class ColaboradorFactory
{
    public static Colaborador Create(
        string nomeCompleto,
        string cpf,
        string rg,
        string email,
        string telefone,
        DateTime dataNascimento,
        DateTime dataAdmissao,
        Cargo cargo,
        Departamento departamento)
    {
        if (string.IsNullOrEmpty(nomeCompleto))
            throw new ArgumentException("Nome completo é obrigatório.");

        // Usa o construtor público em vez da inicialização por propriedades
        return new Colaborador(
            nomeCompleto,
            cpf,
            rg,
            email,
            telefone,
            dataNascimento,
            dataAdmissao,
            cargo,
            departamento
        );
    }
}