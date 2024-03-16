

using Microsoft.Extensions.DependencyInjection;
using Ventas.Application.Contracts.Repositories;
using Ventas.Application.Contracts.Services;
using Ventas.Application.Dtos.Users;
using Ventas.Application.Services;
using Ventas.Infrastructure.Repository;

namespace Ventas.IoC.UserDependency
{
    public static class UserDependency
    {
        public static void AddUserDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService<UserCreateDto, UserUpdateDto>, UserService>();
        }
    }
}
