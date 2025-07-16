using Collaborators.Application.Commands.Collaborators;
using Collaborators.Domain.Interfaces;
using Collaborators.Infra.Context;
using Collaborators.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Collaborators.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Registrar DbContext (PostgreSQL)
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("NPSqlConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        // Registrar Repositórios
        services.AddScoped<IColaboradorRepository, ColaboradorRepository>();

        // Registrar MediatR (Command Handlers)
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(CreateColaboradorCommandHandler).Assembly));

        return services;
    }
}