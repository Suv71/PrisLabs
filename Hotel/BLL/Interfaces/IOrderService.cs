using System;
using System.Collections.Generic;
using Model;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void Add(Order order);

        void Update(Guid orderId, Order order);

        void Delete(Guid orderId);

        IEnumerable<Order> GetAll();
    }
}
