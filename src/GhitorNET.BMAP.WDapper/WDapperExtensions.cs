using System.Data;
using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;

namespace GhitorNET.BMAP.WDapper;

public static class WDapperExtensions
{
    public static IServiceCollection AddWDapper(this IServiceCollection services, IDbConnection connection,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        switch (serviceLifetime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton<IDapperConnection, DapperConnection>(_ => new DapperConnection(connection));
                break;
            case ServiceLifetime.Transient:
                services.AddTransient<IDapperConnection, DapperConnection>(_ => new DapperConnection(connection));
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped<IDapperConnection, DapperConnection>(_ => new DapperConnection(connection));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(serviceLifetime), serviceLifetime, null);
        }

        return services;
    }

    public static IServiceCollection AddWDapper(this IServiceCollection services, DbConnection connection,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        switch (serviceLifetime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton<IDapperImplConnection, DapperImplConnection>(_ =>
                    new DapperImplConnection(connection));
                break;
            case ServiceLifetime.Transient:
                services.AddTransient<IDapperImplConnection, DapperImplConnection>(_ =>
                    new DapperImplConnection(connection));
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped<IDapperImplConnection, DapperImplConnection>(_ =>
                    new DapperImplConnection(connection));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(serviceLifetime), serviceLifetime, null);
        }

        return services;
    }
}