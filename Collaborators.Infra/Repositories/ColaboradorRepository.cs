using Collaborators.Domain.Entities;
using Collaborators.Domain.Interfaces;
using Collaborators.Infra.Context;
using System.Threading.Tasks;

namespace Collaborators.Infra.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly AppDbContext _context;

        public ColaboradorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Colaborador colaborador)
        {
            await _context.Colaboradores.AddAsync(colaborador);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}