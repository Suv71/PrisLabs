using BLL.Implementation;
using BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<IPersonService, PersonService>();

            return services;
        }
    }
}