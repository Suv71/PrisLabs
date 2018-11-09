using DAL.Database;
using DAL.Implementation;
using DAL.Implementation.Database;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddLocalRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IOrderRepository, LocalOrderRepository>();
            services.AddSingleton<IRoomRepository, LocalRoomRepository>();
            services.AddSingleton<IRoomTypeRepository, LocalRoomTypeRepository>();

            return services;
        }

        public static IServiceCollection AddDbRepositories(this IServiceCollection services)
        {
            var dbConnectionString = "Host=localhost;Username=postgres;Password=root;Database=Pris.Hotel";
            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(dbConnectionString, o => o.MigrationsAssembly("DAL")));

            services.AddScoped<IOrderRepository, DbOrderRepository>();
            services.AddScoped<IRoomRepository, DbRoomRepository>();
            services.AddScoped<IRoomTypeRepository, DbRoomTypeRepository>();

            services.AddScoped<DatabaseInitializer>();

            return services;
        }
    }
}