using Microsoft.EntityFrameworkCore;
using Ventas.IoC.DatabaseDependecy;
using Ventas.IoC.LoggerDependency;
using Ventas.IoC.SalesDependency;
using Ventas.IoC.UserDependency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabase(builder.Configuration.GetConnectionString("Ventas"));
builder.Services.AddLoggerDependency();
builder.Services.AddSalesDependencies();
builder.Services.AddUserDependency();


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
