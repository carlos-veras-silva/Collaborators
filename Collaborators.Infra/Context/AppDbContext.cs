using Collaborators.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Collaborators.Infra.Mappings;

namespace Collaborators.Infra.Context;

public class AppDbContext : DbContext
{
    public DbSet<Colaborador> Colaboradores { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.ApplyConfiguration(new CollaboratorMap());

        base.OnModelCreating(modelBuilder);
    }
}