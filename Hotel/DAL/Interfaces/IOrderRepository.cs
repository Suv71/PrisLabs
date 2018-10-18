using Model;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);

        void Update(Guid orderId, Order order);

        void Delete(Guid orderId);

        IEnumerable<Order> GetAll();
    }
}
