using Microsoft.Extensions.DependencyInjection;
using Ventas.Application.Contracts.Repositories;
using Ventas.Application.Contracts.Services;
using Ventas.Application.Dtos.Sales;
using Ventas.Application.Services;
using Ventas.Infrastructure.Repository;

namespace Ventas.IoC.SalesDependency
{
    public static class SalesDependency
    {
        public static void AddSalesDependencies(this IServiceCollection services) {
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleService<SaleCreateDto, SaleUpdateDto>, SaleService>();
        }
    }
}
