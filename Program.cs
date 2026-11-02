using Azure.Core;
using BlogApi.Data;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.DependencyInjection;
using BlogApi.MIddleware;
var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddDbContext<BlogDbcontext>(options=>options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionalHandler>();
builder.Services.AddProblemDetails();


var app = builder.Build();

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
