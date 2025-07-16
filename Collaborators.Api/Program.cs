using Collaborators.Application.Commands.Collaborators;
using Collaborators.Domain.Interfaces;
using Collaborators.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateColaboradorCommandHandler).Assembly));

// Configuração do AutoMapper
//builder.Services.AddAutoMapper(typeof(ColaboradorMappingProfile));

// Configuração do EF Core
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.(builder.Configuration.GetConnectionString("NPSqlConnection")));

// Registro do Repository
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
