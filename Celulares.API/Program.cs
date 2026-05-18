using Celulares.Application.Interfaces;
using Celulares.Application.Services;
using Celulares.Domain.Interfaces;
using Celulares.Infrastructure.Data;
using Celulares.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure In-Memory Database for demonstration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("CelularesDb"));

// Dependency Injection Configuration
builder.Services.AddScoped<ICelularRepository, CelularRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICelularApplicationService, CelularApplicationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Celulares API V1");
    c.RoutePrefix = string.Empty; // Serve swagger UI at root
});

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
