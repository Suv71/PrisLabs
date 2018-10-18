using DAL.Implementation;
using Hotel.ViewModels.Orders;
using Hotel.ViewModels.Rooms;

namespace Hotel.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public RoomsTabViewModel RoomsTabVM { get; set; }

        public OrdersTabViewModel OrdersTabVM { get; set; }

        public MainViewModel()
        {
            var roomTypesRepository = new LocalRoomTypeRepository();
            var roomsRepository = new LocalRoomRepository(roomTypesRepository);
            var ordersRepository = new LocalOrderRepository();

            RoomsTabVM = new RoomsTabViewModel(roomsRepository, roomTypesRepository);
            OrdersTabVM = new OrdersTabViewModel();
        }
    }
}
