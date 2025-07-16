using Bogus;
using Bogus.Extensions.Brazil;
using Collaborators.Domain.Entities;
using Collaborators.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Collaborators.Domain.Helpers
{
    public static class ColaboradorRandomGenerator
    {
        private static readonly Faker<Colaborador> _faker;
        private static readonly Random _random = new Random();

        static ColaboradorRandomGenerator()
        {
            _faker = new Faker<Colaborador>("pt_BR")
                .CustomInstantiator(f => new Colaborador(
                    nomeCompleto: f.Name.FullName(),
                    cpf: f.Person.Cpf(),
                    rg: f.Random.Replace("##.###.###-#"),
                    email: f.Internet.Email(),
                    telefone: f.Phone.PhoneNumber("(##) 9####-####"),
                    dataNascimento: f.Date.Between(new DateTime(1950, 1, 1), new DateTime(2000, 12, 31)),
                    dataAdmissao: DateTime.Now.AddDays(-_random.Next(1, 365 * 5)), // Admite até 5 anos atrás
                    cargo: GetRandomCargo(),
                    departamento: GetRandomDepartamento()
                ));
        }

        public static List<Colaborador> GerarColaboradores(int quantidade)
        {
            return _faker.Generate(quantidade);
        }

        private static Cargo GetRandomCargo()
        {
            var cargos = Enum.GetValues(typeof(Cargo));
            return (Cargo)cargos.GetValue(_random.Next(cargos.Length))!;
        }

        private static Departamento GetRandomDepartamento()
        {
            var departamentos = Enum.GetValues(typeof(Departamento));
            return (Departamento)departamentos.GetValue(_random.Next(departamentos.Length))!;
        }

        // Método para gerar dados randômicos que podem ser usados em testes
        //public static CreateColaboradorCommand GerarCommand()
        //{
        //    var colaborador = _faker.Generate();
        //    return new CreateColaboradorCommand
        //    {
        //        NomeCompleto = colaborador.NomeCompleto,
        //        CPF = colaborador.CPF,
        //        RG = colaborador.RG,
        //        Email = colaborador.Email,
        //        Telefone = colaborador.Telefone,
        //        DataNascimento = colaborador.DataNascimento,
        //        DataAdmissao = colaborador.DataAdmissao,
        //        Cargo = colaborador.Cargo,
        //        Departamento = colaborador.Departamento
        //    };
        //}
    }
}