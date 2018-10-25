using Hotel.ViewModels.Orders;
using Hotel.ViewModels.Rooms;

namespace Hotel.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public RoomsTabViewModel RoomsTabVM { get; }

        public OrdersTabViewModel OrdersTabVM { get; }

        public MainViewModel(RoomsTabViewModel roomsTabVM, OrdersTabViewModel ordersTabVM)
        {
            RoomsTabVM = roomsTabVM;
            OrdersTabVM = ordersTabVM;
        }
    }
}
