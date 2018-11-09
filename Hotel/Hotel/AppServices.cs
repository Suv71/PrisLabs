using System;
using BLL;
using DAL;
using Hotel.ViewModels;
using Hotel.ViewModels.Orders;
using Hotel.ViewModels.Rooms;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel
{
    public class AppServices
    {
        private static AppServices _instance;
        private static readonly object InstanceLock = new object();
        private static AppServices GetInstance()
        {
            lock (InstanceLock)
            {
                return _instance ?? (_instance = new AppServices());
            }
        }

        public IServiceProvider ServiceProvider { get; }
        public static AppServices Instance => _instance ?? GetInstance();

        private AppServices()
        {
            var services = new ServiceCollection();

            //ViewModels
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<RoomsTabViewModel>();
            services.AddScoped<AddRoomViewModel>();
            services.AddScoped<EditRoomViewModel>();

            services.AddSingleton<OrdersTabViewModel>();
            services.AddScoped<AddOrderViewModel>();
            services.AddScoped<EditOrderViewModel>();

            //Services
            services.AddDomainServices();

            //Repositiries
            //services.AddLocalRepositories();
            services.AddDbRepositories();


            ServiceProvider = services.BuildServiceProvider();
        }
    }
}