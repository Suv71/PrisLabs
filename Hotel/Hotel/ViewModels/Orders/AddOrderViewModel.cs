using DAL.Interfaces;
using Hotel.Commands;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels.Orders
{
    public class AddOrderViewModel : BaseViewModel
    {
        private readonly OrdersTabViewModel _ordersTabViewModel;
        private readonly IOrderRepository _orderRepository;
        private readonly IRoomRepository _roomRepository;

        public Order Order { get; set; }
        public double Cost { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public Action CloseAction { get; set; }
        public SimpleCommand AddOrderCommand { get; set; }

        public AddOrderViewModel(OrdersTabViewModel ordersTabViewModel, IOrderRepository orderRepository, IRoomRepository roomRepository)
        {
            _ordersTabViewModel = ordersTabViewModel;
            _orderRepository = orderRepository;
            _roomRepository = roomRepository;

            Cost = 0;

            Rooms = _roomRepository.GetAll();

            Order = new Order
            {
                Id = Guid.NewGuid(),
                IsActive = false,
                RoomId = Rooms.First().Id,
                Room = Rooms.First()
            };

            AddOrderCommand = new SimpleCommand(c => AddOrder());
        }

        private void AddOrder()
        {
            try
            {
                _ordersTabViewModel.OrderService.Add(Order);
                Order.Room = _roomRepository.GetById(Order.RoomId);
                _ordersTabViewModel.Orders.Add(Order);
                
                CloseAction();
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void UpdateCost()
        {
            if (Order.LeavedDate > Order.ArrivedDate && Order.ArrivedDate != Order.LeavedDate)
            {
                var selectedRoom = _roomRepository.GetById(Order.RoomId);
                Cost = selectedRoom.Cost * (Order.LeavedDate - Order.ArrivedDate).TotalDays;
                OnPropertyChanged("Cost");
            } 
        }
    }
}
