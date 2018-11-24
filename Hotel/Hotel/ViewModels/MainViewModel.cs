using DAL.Database;
using Hotel.ViewModels.Orders;
using Hotel.ViewModels.Persons;
using Hotel.ViewModels.Rooms;

namespace Hotel.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public RoomsTabViewModel RoomsTabVM { get; }

        public OrdersTabViewModel OrdersTabVM { get; }

        public PersonsTabViewModel PersonsTabVM { get; }

        public MainViewModel(RoomsTabViewModel roomsTabVM, OrdersTabViewModel ordersTabVM, PersonsTabViewModel personsTabVM, DatabaseInitializer initializer)
        {
            RoomsTabVM = roomsTabVM;
            OrdersTabVM = ordersTabVM;
            PersonsTabVM = personsTabVM;

            initializer.Initialize();
        }
    }
}
