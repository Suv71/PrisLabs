using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Implementation
{
    public class LocalOrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders;

        public LocalOrderRepository(IRoomRepository roomsRepository)
        {
            _orders = new List<Order>
            {
                new Order
                {
                    Id = Guid.NewGuid(),
                    RoomId = roomsRepository.GetAll().Single(r => r.Number == 1).Id,
                    ArrivedDate = DateTime.Now,
                    LeavedDate = DateTime.Now.AddDays(1),
                    IsActive = true
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    RoomId = roomsRepository.GetAll().Single(r => r.Number == 2).Id,
                    ArrivedDate = DateTime.Now.AddDays(1),
                    LeavedDate = DateTime.Now.AddDays(2),
                    IsActive = true
                }
            };
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }

        public void Add(Order order)
        {
            _orders.Add(order);
        }

        public void Update(Guid orderId, Order order)
        {
            var orderForUpdate = _orders.Single(r => r.Id == orderId);
            orderForUpdate.ArrivedDate = order.ArrivedDate;
            orderForUpdate.LeavedDate = order.LeavedDate;
            orderForUpdate.RoomId = order.RoomId;
            orderForUpdate.IsActive = order.IsActive;
        }

        public void Delete(Guid roomId)
        {
            var orderForDelete = _orders.Single(r => r.Id == roomId);
            _orders.Remove(orderForDelete);
        }
    }
}
