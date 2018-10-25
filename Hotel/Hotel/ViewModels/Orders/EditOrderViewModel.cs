using Hotel.Commands;
using Model;
using System;

namespace Hotel.ViewModels.Orders
{
    public class EditOrderViewModel : BaseViewModel
    {
        private readonly OrdersTabViewModel _ordersTabViewModel;
        //private readonly IOrderRepository _orderRepository;

        public Order EditedOrder { get; set; }
        public Action CloseAction { get; set; }
        public SimpleCommand UpdateOrderCommand { get; set; }

        public EditOrderViewModel(OrdersTabViewModel ordersTabViewModel/*, IOrderRepository orderRepository*/)
        {
            _ordersTabViewModel = ordersTabViewModel;
            //_orderRepository = orderRepository;

            EditedOrder = new Order
            {
                Id = _ordersTabViewModel.SelectedOrder.Id,
                ArrivedDate = _ordersTabViewModel.SelectedOrder.ArrivedDate,
                LeavedDate = _ordersTabViewModel.SelectedOrder.LeavedDate,
                IsActive = _ordersTabViewModel.SelectedOrder.IsActive,
                RoomId = _ordersTabViewModel.SelectedOrder.RoomId,
                Room = _ordersTabViewModel.SelectedOrder.Room
            };

            UpdateOrderCommand = new SimpleCommand(c => UpdateOrder());
        }

        void UpdateOrder()
        {
            _ordersTabViewModel.OrderService.Update(EditedOrder.Id, EditedOrder);
            var index = _ordersTabViewModel.Orders.IndexOf(_ordersTabViewModel.SelectedOrder);
            _ordersTabViewModel.Orders[index] = EditedOrder;
            _ordersTabViewModel.SelectedOrder = EditedOrder;
            CloseAction();
        }

        //public void UpdateCost()
        //{
        //    var selectedRoomType = _roomTypeRepository.GetById(EditedRoom.RoomTypeId);
        //    EditedRoom.Cost = EditedRoom.Capacity * selectedRoomType.BaseCost;
        //    EditedRoom.RoomType = selectedRoomType;
        //    OnPropertyChanged("EditedRoom");
        //}
    }
}
