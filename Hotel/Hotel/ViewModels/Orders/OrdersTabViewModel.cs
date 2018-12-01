using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public List<Order> Orders;

        public ObservableCollection<Order> ViewOrders { get; set; }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public DateTime ArrivedDateFilter { get; set; }

        public DateTime LeavedDateFilter { get; set; }

        public string FullNameFilter { get; set; }

        public SimpleCommand OpenAddOrderWindowCommand { get; set; }

        public SimpleCommand OpenEditOrderWindowCommand { get; set; }

        public SimpleCommand DeleteOrderCommand { get; set; }

        public SimpleCommand SearchCommand { get; set; }

        public OrdersTabViewModel(IRoomService roomsService, IOrderService ordersService)
        {
            OrderService = ordersService;
            Orders = new List<Order>(OrderService.GetAll());
            ViewOrders = new ObservableCollection<Order>(Orders);
            OpenAddOrderWindowCommand = new SimpleCommand(c => OpenAddOrderWindow());
            OpenEditOrderWindowCommand = new SimpleCommand(c => OpenEditOrderWindow());
            DeleteOrderCommand = new SimpleCommand(c => DeleteOrder());
            SearchCommand = new SimpleCommand(c => Search());

            foreach (var order in Orders)
            {
                order.Room = roomsService.GetById(order.RoomId);
            }

            ArrivedDateFilter = DateTime.MinValue;
            LeavedDateFilter = DateTime.MinValue;
        }

        private void OpenAddOrderWindow()
        {
            var addOrderWindow = new AddOrderWindow();
            addOrderWindow.Show();
        }

        private void Search()
        {
            IEnumerable<Order> result = new List<Order>(Orders);
            if (ArrivedDateFilter != DateTime.MinValue)
            {
                result = result.Where(x => x.ArrivedDate >= ArrivedDateFilter);
            }
            if (LeavedDateFilter != DateTime.MinValue)
            {
                result = result.Where(x => x.LeavedDate <= LeavedDateFilter);
            }
            if (!string.IsNullOrEmpty(FullNameFilter))
            {
                result = result.Where(x => x.Person.FullName.Contains(FullNameFilter));
            }

            ViewOrders = new ObservableCollection<Order>(result);
            OnPropertyChanged("ViewOrders");
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