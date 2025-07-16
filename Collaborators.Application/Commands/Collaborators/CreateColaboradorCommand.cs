using Collaborators.Domain.Enums;
using MediatR;
using System;

namespace Collaborators.Application.Commands.Collaborators
{
    
    public class CreateColaboradorCommand : IRequest<int> 
    {
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public Cargo Cargo { get; set; }
        public Departamento Departamento { get; set; }
    }
}
