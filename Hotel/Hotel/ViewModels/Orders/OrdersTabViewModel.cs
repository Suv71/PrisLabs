using System.Collections.ObjectModel;
using BLL.Interfaces;
using Hotel.Commands;
using Hotel.Views;
using Model;

namespace Hotel.ViewModels.Orders
{
    public class OrdersTabViewModel : BaseViewModel
    {
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

        public OrdersTabViewModel(IRoomService roomsService, IOrderService ordersService)
        {
            OrderService = ordersService;
            Orders = new ObservableCollection<Order>(OrderService.GetAll());
            OpenAddOrderWindowCommand = new SimpleCommand(c => OpenAddOrderWindow());
            OpenEditOrderWindowCommand = new SimpleCommand(c => OpenEditOrderWindow());
            DeleteOrderCommand = new SimpleCommand(c => DeleteOrder());

            foreach (var order in Orders)
            {
                order.Room = roomsService.GetById(order.RoomId);
            }
        }

        private void OpenAddOrderWindow()
        {
            var addOrderWindow = new AddOrderWindow();
            addOrderWindow.Show();
        }

        private void OpenEditOrderWindow()
        {
            if (SelectedOrder != null)
            {
                var editOrderWindow = new EditOrderWindow();
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