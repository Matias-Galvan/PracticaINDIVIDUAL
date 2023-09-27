using Aplication.Interfaces;
using Aplication.UseCase.Services;
using Application.Interfaces.Command;
using Application.Interfaces.Queries;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using PracticaINDIVIDUAL.API.Commands.FuncionCMD;
using PracticaINDIVIDUAL.API.Queries.Funcion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyección de dependencias y CQRS
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<CineDBContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddScoped<IFuncionCommand, FuncionCommand>();
builder.Services.AddScoped<IFuncionQuery, FuncionQuery>();
builder.Services.AddScoped<IFuncionService, FuncionService>();
builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<IPeliculaService, PeliculaService>();
builder.Services.AddScoped<ISalaService, SalaService>();



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
