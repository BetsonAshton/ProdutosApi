using ApiProdutos.Application.Interfaces;
using ApiProdutos.Application.Services;
using ApiProdutos.Infra.Data.Contexts;
using ApiProdutos.Infra.Data.Repositories;
using ApiProdutosDomain.Interfaces;
using ApiProdutosDomain.Interfaces.Services;
using ApiProdutosDomain.Services;
using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ICategoriaDomainService, CategoriaDomainService>();
builder.Services.AddTransient<IProdutoDomainService, ProdutoDomainService>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<ICategoriaAppService, CategoriaAppService>();
builder.Services.AddTransient<IProdutoAppService, ProdutoAppService>();
builder.Services.AddTransient<DataContext>();

//configurar o AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(
    s => s.AddPolicy("DefaultPolicy", builder =>
    {
        builder.AllowAnyOrigin() //qualquer origem pode acessar a API
            .AllowAnyMethod() //qualquer método (POST, PUT, DELETE, GET)
            .AllowAnyHeader(); //qualquer informação de cabeçalho
    })
);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();
