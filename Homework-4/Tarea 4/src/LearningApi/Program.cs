//Miguel Zaiter 2025-0928

using AutoMapper;
using LearningApi.Application.Contract;
using LearningApi.Application.Services;
using LearningApi.Infraestructure.Interfaces;
using LearningApi.Infraestructure.Repositories;
using LearningApi.Mappings;
using LearningApi.Models.Dtos;
using LearningApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LearningApi.Application.Services;
using LearningApi.Application.Contract;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDataContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


// Registrar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
}, typeof(Program).Assembly);

//Repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//Service
builder.Services.AddScoped<ProductService, ProductService>();


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
