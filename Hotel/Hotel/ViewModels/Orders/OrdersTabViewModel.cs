using System.Collections.ObjectModel;
using BLL.Implementation;
using BLL.Interfaces;
using DAL.Interfaces;
using Hotel.Commands;
using Hotel.Views;
using Model;

namespace Hotel.ViewModels.Orders
{
    public class OrdersTabViewModel : BaseViewModel
    {
        private readonly IOrderRepository _ordersRepository;
        private readonly IRoomRepository _roomsRepository;
        private Order _selectedOrder;

        public IOrderService OrderService;

        public ObservableCollection<Order> Orders { get; set; }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public SimpleCommand OpenAddOrderWindowCommand { get; set; }

        public SimpleCommand OpenEditOrderWindowCommand { get; set; }

        public SimpleCommand DeleteOrderCommand { get; set; }

        public OrdersTabViewModel(IRoomRepository roomsRepository, IOrderRepository ordersRepository)
        {
            _roomsRepository = roomsRepository;
            _ordersRepository = ordersRepository;
            OrderService = new OrderService(ordersRepository);
            Orders = new ObservableCollection<Order>(OrderService.GetAll());
            OpenAddOrderWindowCommand = new SimpleCommand(c => OpenAddOrderWindow());
            OpenEditOrderWindowCommand = new SimpleCommand(c => OpenEditOrderWindow());
            DeleteOrderCommand = new SimpleCommand(c => DeleteOrder());

            foreach (var order in Orders)
            {
                order.Room = roomsRepository.GetById(order.RoomId);
            }
        }



        private void OpenAddOrderWindow()
        {
            var addOrderWindow = new AddOrderWindow();
            addOrderWindow.DataContext = new AddOrderViewModel(this, _ordersRepository, _roomsRepository)
            {
                CloseAction = addOrderWindow.Close
            };
            addOrderWindow.Show();
        }

        private void OpenEditOrderWindow()
        {
            if (SelectedOrder != null)
            {
                var editOrderWindow = new EditOrderWindow();
                editOrderWindow.DataContext = new EditOrderViewModel(this)
                {
                    EditedOrder = new Order
                    {
                        Id = SelectedOrder.Id,
                        ArrivedDate = SelectedOrder.ArrivedDate,
                        LeavedDate = SelectedOrder.LeavedDate,
                        IsActive = SelectedOrder.IsActive,
                        RoomId = SelectedOrder.RoomId,
                        Room = SelectedOrder.Room
                    },
                    CloseAction = editOrderWindow.Close
                };
                editOrderWindow.Show();
            }
        }

        private void DeleteOrder()
        {
            if (SelectedOrder != null)
            {
                OrderService.Delete(SelectedOrder.Id);
                Orders.Remove(SelectedOrder);
            }
        }
    }
}