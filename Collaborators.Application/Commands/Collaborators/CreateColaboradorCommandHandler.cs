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
        if (string.IsNullOrEmpty(request.NomeCompleto))
            throw new ArgumentException("Nome completo é obrigatório.");

        var colaborador = ColaboradorFactory.Create
        (
            request.NomeCompleto,
            request.CPF,
            request.RG,
            request.Email,
            request.Telefone,
            request.DataNascimento,
            request.DataAdmissao,
            request.Cargo,
            request.Departamento
        );

        // Persistir no banco
        await _colaboradorRepository.AddAsync(colaborador);
        await _colaboradorRepository.SaveChangesAsync();

        return colaborador.Id; // Retorna o ID gerado
    }
}