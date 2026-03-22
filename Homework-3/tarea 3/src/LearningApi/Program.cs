//Miguel Zaiter 2025-0928

using Microsoft.EntityFrameworkCore;
using LearningApi.Persistence;
using LearningApi.Models.Dtos;
using AutoMapper;
using LearningApi.Infraestructure.Interfaces;
using LearningApi.Infraestructure.Repositories;
using LearningApi.Mappings;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDataContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

//builder.Services.AddScoped<GenericRepository<Complaintype>>();

//builder.Services.AddControllers();

// Registrar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
}, typeof(Program).Assembly);

builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Configurar DbContext con la cadena de conexión
//builder.Services.AddDbContext<ApplicationDataContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
