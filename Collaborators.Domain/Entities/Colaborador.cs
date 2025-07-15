using Collaborators.Domain.Enums;
using System;

namespace Collaborators.Domain.Entities
{
    public class Colaborador
    {
        public int Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataAdmissao { get; private set; }
        public DateTime? DataDemissao { get; private set; }
        public bool Ativo { get; private set; }
        
        public Cargo Cargo { get; private set; }
        public Departamento Departamento { get; private set; }

        // Construtor privado (para uso da Factory)
        private Colaborador() { }

        // Métodos de domínio
        public void Ativar() => Ativo = true;
        public void Demitir(DateTime dataDemissao)
        {
            Ativo = false;
            DataDemissao = dataDemissao;
        }
    }
}
