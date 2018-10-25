using DAL.Implementation;
using DAL.Interfaces;
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
    }
}