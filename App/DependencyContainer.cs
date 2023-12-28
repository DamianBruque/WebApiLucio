

using DataAccess;
using DataAccess.DBAccess;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using Services.Abstractions;

public static class DependencyContainer
{
    public static IServiceCollection AddProjectContextOracle(this IServiceCollection services)
    {
        services.AddDbContext<ProjectContext>(options => options.UseOracle(connectionString: Environment.GetEnvironmentVariable("ORACLE_CONNECTION_STRING")));
        return services;
    }
    public static IServiceCollection AddConnection(this IServiceCollection service)
    {
        // Inyección de dependencias de la conexión a la base de datos
        service.AddScoped(typeof(IConnection), typeof(OracleDbConnection));
        return service;
    }
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // Inyección de dependencias de los servicios
        services.AddScoped(typeof(IAuthService), typeof(AuthService));
        services.AddScoped(typeof(IRoleService), typeof(RoleService));
        services.AddScoped(typeof(IUserService), typeof(UserService));
        services.AddScoped(typeof(IJwtService), typeof(JwtService));
        services.AddScoped(typeof(IProductService), typeof(ProductService));

        return services;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Inyección de dependencias de los repositorios
        services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
        services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));

        return services;
    }
}
