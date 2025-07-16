using Collaborators.Domain.Entities;
using System.Threading.Tasks;

namespace Collaborators.Domain.Interfaces
{
    public interface IColaboradorRepository
    {
        Task AddAsync(Colaborador colaborador);
        Task SaveChangesAsync();
    }
}