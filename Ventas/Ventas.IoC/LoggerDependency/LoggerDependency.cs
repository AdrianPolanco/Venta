using Microsoft.Extensions.DependencyInjection;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Logger;

namespace Ventas.IoC.LoggerDependency
{
    public static class LoggerDependency
    {
        public static void AddLoggerDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));
        }
    }
}
