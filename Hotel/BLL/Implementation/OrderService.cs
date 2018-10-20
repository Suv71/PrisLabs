using BLL.Interfaces;
using System;
using System.Collections.Generic;
using DAL.Interfaces;
using Model;
using System.Linq;

namespace BLL.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _ordersRepository;

        public OrderService(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public void Add(Order order)
        {
            var orders = GetAll().Where(o => o.RoomId == order.RoomId);
            if (orders.Any(o => CheckRoomPeriodIntersect(order.ArrivedDate, order.LeavedDate, o.ArrivedDate, o.LeavedDate)))
            {
                throw new InvalidOperationException("Даты заказа пересекаются с существующими датами заказов этой комнаты");
            }
            _ordersRepository.Add(order);
        }

        public void Update(Guid orderId, Order order)
        {
            _ordersRepository.Update(orderId, order);
        }

        public void Delete(Guid orderId)
        {
            _ordersRepository.Delete(orderId);
        }

        public IEnumerable<Order> GetAll()
        {
            return _ordersRepository.GetAll();
        }

        private bool CheckRoomPeriodIntersect(DateTime addedArrivalDate, DateTime addedLeavedDate, DateTime roomArrivalDate, DateTime roomLeavedDate)
        {
            return (addedArrivalDate >= roomArrivalDate && addedArrivalDate <= roomLeavedDate) 
                    || 
                    (addedLeavedDate >= roomArrivalDate && addedLeavedDate <= roomLeavedDate)
                    ||
                    (roomArrivalDate >= addedArrivalDate && roomArrivalDate <= addedLeavedDate)
                    ||
                    (roomLeavedDate >= addedArrivalDate && roomLeavedDate <= addedLeavedDate);

        }
    }
}
