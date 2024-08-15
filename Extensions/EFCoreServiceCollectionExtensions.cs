using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore;

namespace PrintSerApp.Extensions
{
    public static class EFCoreServiceCollectionExtensions
    {
        /// <summary>
        /// 增加 Entity Framework 数据库操作服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <param name="contextLifetime"></param>
        /// <param name="optionsLifetime"></param>
        /// <returns></returns>
        public static IServiceCollection AddEntityFrameworkCore<TContext>(this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null, ServiceLifetime contextLifetime = ServiceLifetime.Scoped, ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
            where TContext : DbContext
        {
            services.AddDbContext<TContext>(optionsAction, contextLifetime, optionsLifetime);
            services.Add(new ServiceDescriptor(typeof(IDataService<>), typeof(DefaultDataService<>), contextLifetime));
            services.Add(new ServiceDescriptor(typeof(Func<IEntityFrameworkCoreDataService, DbContext>), provider =>
            {
                DbContext DbContextResolve(IEntityFrameworkCoreDataService server)
                {
                    return provider.GetRequiredService<TContext>();
                }
                return (Func<IEntityFrameworkCoreDataService, DbContext>)DbContextResolve;
            }, contextLifetime));
            return services;
        }
    }
}