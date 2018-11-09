using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL.Implementation.Database
{
    public class DbOrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _context;

        public DbOrderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(Guid orderId, Order order)
        {
            var updatedOrder = _context.Orders.Single(o => o.Id == orderId);
            updatedOrder.IsActive = order.IsActive;
            updatedOrder.ArrivedDate = order.ArrivedDate;
            updatedOrder.LeavedDate = order.LeavedDate;
            updatedOrder.RoomId = order.RoomId;
            _context.SaveChanges();
        }

        public void Delete(Guid orderId)
        {
            var deletingOrder = _context.Orders.Single(o => o.Id == orderId);
            _context.Orders.Remove(deletingOrder);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(o => o.Room).ToList();
        }
    }
}