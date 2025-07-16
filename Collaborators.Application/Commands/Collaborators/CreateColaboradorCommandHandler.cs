using Collaborators.Domain.Entities;
using Collaborators.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Collaborators.Application.Commands.Collaborators;

public class CreateColaboradorCommandHandler : IRequestHandler<CreateColaboradorCommand, int>
{
    private readonly IColaboradorRepository _colaboradorRepository;

    public CreateColaboradorCommandHandler(IColaboradorRepository colaboradorRepository)
    {
        _colaboradorRepository = colaboradorRepository;
    }

    public async Task<int> Handle(CreateColaboradorCommand request, CancellationToken cancellationToken)
    {
        // Validações (pode usar FluentValidation se necessário)
        if (string.IsNullOrEmpty(request.NomeCompleto))
            throw new ArgumentException("Nome completo é obrigatório.");

        // Criar a entidade de domínio
        var colaborador = new Colaborador
        {
            NomeCompleto = request.NomeCompleto,
            CPF = request.CPF,
            RG = request.RG,
            Email = request.Email,
            Telefone = request.Telefone,
            DataNascimento = request.DataNascimento,
            DataAdmissao = request.DataAdmissao,
            Cargo = request.Cargo,
            Departamento = request.Departamento,
            Ativo = true // Por padrão, colaborador é criado como ativo
        };

        // Persistir no banco
        await _colaboradorRepository.AddAsync(colaborador);
        await _colaboradorRepository.SaveChangesAsync();

        return colaborador.Id; // Retorna o ID gerado
    }
}