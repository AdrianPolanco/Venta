using Microsoft.EntityFrameworkCore;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Logger;
using Ventas.Application.Contracts;
using Ventas.Infrastructure.Repository;
using Ventas.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Ventas")));
builder.Services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
