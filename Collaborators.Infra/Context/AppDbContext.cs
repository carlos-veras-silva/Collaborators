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
        // Aplica as configurações de Fluent Mapping
        modelBuilder.ApplyConfiguration(new CollaboratorMap());

        // Configuração adicional para enums (opcional)
        modelBuilder
            .Entity<Colaborador>()
            .Property(c => c.Cargo)
            .HasConversion<string>(); // Armazena enums como strings no BD

        modelBuilder
            .Entity<Colaborador>()
            .Property(c => c.Departamento)
            .HasConversion<string>();

        base.OnModelCreating(modelBuilder);
    }
}