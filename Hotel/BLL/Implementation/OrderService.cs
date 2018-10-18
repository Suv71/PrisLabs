using BLL.Interfaces;
using System;
using System.Collections.Generic;
using DAL.Interfaces;
using Model;

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
    }
}
